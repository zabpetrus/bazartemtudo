import csv
import json
from collections import defaultdict
from datetime import datetime


def parse_address(row, prefix):
    return {
        "street": row[f'{prefix}-address-1'],
        "city": row[f'{prefix}-city'],
        "state": row[f'{prefix}-state'],
        "postalCode": row[f'{prefix}-postal-code'],
        "country": row[f'{prefix}-country']
    }


def csv_to_json(csv_file):
    orders = defaultdict(lambda: {
        "order": {
            "orderId": "",
            "orderDate": "",
            "orderStatus": "Pending",
            "customer": {
                "customerId": "",
                "firstName": "",
                "lastName": "",
                "email": "",
                "phone": "",
                "shippingAddress": {},
                "billingAddress": {}
            },
            "items": [],
            "payment": {
                "paymentMethod": "CreditCard",
                "paymentStatus": "Authorized",
                "transactionId": "",
                "amount": 0.0,
                "currency": ""
            },
            "shipping": {
                "shippingMethod": "",
                "shippingCost": 0.0,
                "currency": "",
                "trackingNumber": "",
                "carrier": ""
            },
            "totals": {
                "subtotal": 0.0,
                "shipping": 0.0,
                "tax": 0.0,
                "total": 0.0,
                "currency": ""
            }
        }
    })

    try:
        with open(csv_file, newline='', encoding='utf-8') as csvfile:
            reader = csv.DictReader(csvfile, delimiter=';')
            for row in reader:
                order_id = row['order-id']
                order = orders[order_id]

                # Informações do pedido
                order['order']['orderId'] = order_id
                order['order']['orderDate'] = row['purchase-date'] + "T00:00:00Z"
                order['order']['orderStatus'] = "Pending"

                # Informações do cliente
                order['order']['customer']['customerId'] = row['cpf']
                name_parts = row['buyer-name'].split(' ', 1)
                order['order']['customer']['firstName'] = name_parts[0]
                order['order']['customer']['lastName'] = name_parts[1] if len(name_parts) > 1 else ""
                order['order']['customer']['email'] = row['buyer-email']
                order['order']['customer']['phone'] = row['buyer-phone-number']

                # Endereço de envio e cobrança (assumindo que são iguais)
                order['order']['customer']['shippingAddress'] = parse_address(row, 'ship')
                order['order']['customer']['billingAddress'] = order['order']['customer']['shippingAddress']

                # Itens comprados
                try:
                    unit_price = float(row['item-price'].replace(',', '.'))
                    quantity = int(row['quantity-purchased'])
                except ValueError:
                    unit_price = 0.0
                    quantity = 0

                item = {
                    "itemId": row['order-item-id'],
                    "productId": row['sku'],
                    "productName": row['product-name'],
                    "quantity": quantity,
                    "unitPrice": unit_price,
                    "totalPrice": unit_price * quantity,
                    "currency": row['currency'],
                    "attributes": {}
                }
                order['order']['items'].append(item)

                # Pagamento (somente uma vez por pedido)
                if not order['order']['payment']['transactionId']:
                    order['order']['payment']['transactionId'] = "trans" + order_id
                    order['order']['payment']['amount'] += item['totalPrice']
                    order['order']['payment']['currency'] = row['currency']

                # Informações de envio (somente uma vez por pedido)
                if not order['order']['shipping']['shippingMethod']:
                    order['order']['shipping']['shippingMethod'] = row['ship-service-level']
                    order['order']['shipping']['shippingCost'] = 10.00
                    order['order']['shipping']['currency'] = row['currency']
                    order['order']['shipping']['trackingNumber'] = "track" + order_id
                    order['order']['shipping']['carrier'] = "CarrierName"

                # Totais do pedido
                order['order']['totals']['subtotal'] += item['totalPrice']
                order['order']['totals']['shipping'] = order['order']['shipping']['shippingCost']
                order['order']['totals']['tax'] = 30.00
                order['order']['totals']['total'] = order['order']['totals']['subtotal'] + order['order']['totals']['shipping'] + order['order']['totals']['tax']
                order['order']['totals']['currency'] = row['currency']
    except FileNotFoundError:
        print(f"File {csv_file} not found.")
    except KeyError as e:
        print(f"Missing column in CSV file: {e}")

    return json.dumps(list(orders.values()), indent=4)


def main():
    # Caminho para o arquivo CSV
    csv_file = 'source.csv'

    # Convertemos o CSV para JSON
    json_output = csv_to_json(csv_file)

    with open('pedido.json', 'w', encoding='utf-8') as jsonfile:
        jsonfile.write(json_output)

    print("JSON salvo em pedido.json")

    # Imprimindo o JSON resultante
    print(json_output)


if __name__ == "__main__":
    main()
