# backend-challenge-ecommerce
Desafio Hash

# Pré requisitos para execução da API

1 - .NET Core 3.1 \
2 - IDE Visual Studio ou VS Code https://code.visualstudio.com/download \
3 - POSTMAN  https://dl.pstmn.io/download/latest/win64 \
5 - Docker Desktop https://desktop.docker.com/win/stable/amd64/Docker%20Desktop%20Installer.exe

# Instruções para Teste

1 - Criar a pasta para o clone do projeto. \
2 - Abrir o prompt de comando e acessar a pasta criada. \
3 - Execucar o comando <git clone https://github.com/RobinsonFernandesCampos/backend-challenge-ecommerce.git> \
4 - Abrir o projeto na IDE Visual Studio \
5 - Clicar no botão F5 \
6 - Abrir o POSTMAN e criar uma requisição de POST a API \
7 - Verificar a porta a qual foi publicada a api no Docker e colocar na url abaixo no lugar da string <PortaAPIDocker>. \
7 - Verificar o IP local da sua máquina e colocar na url abaixo no lugar da string <IpLocal>. \
7 - Colocar a url no POSTMAN "http://<IpLocal>:<PortaAPIDocker>/api/backendChallenge/eCommerce/carrinho" \
8 - Colocar no body do request o json padrão com os produtos do carrinho e suas respectivas quantidades \
9 - Clicar no botão Send \
10 - Pronto, adorei o teste, me deparei com alguns pontos que precisei estudar para implementar, valeu a pena me diverti e aprendi mais algumas coisas.

# Exemplo de resultado em ambiente local
![img](https://github.com/RobinsonFernandesCampos/backend-challenge-ecommerce/blob/main/ExemploResultadoExecucao.png)

# Exemplo de Response Json 

```javascript
{
    "total_amount": 383847,
    "total_amount_with_discount": 375380,
    "total_discount": 8467,
    "products": [
        {
            "id": 1,
            "quantity": 1,
            "unit_amount": 15157,
            "total_amount": 15157,
            "discount": 758,
            "is_gift": false
        },
        {
            "id": 2,
            "quantity": 2,
            "unit_amount": 93811,
            "total_amount": 187622,
            "discount": 4691,
            "is_gift": false
        },
        {
            "id": 3,
            "quantity": 3,
            "unit_amount": 60356,
            "total_amount": 181068,
            "discount": 3018,
            "is_gift": false
        },
        {
            "id": 6,
            "quantity": 1,
            "unit_amount": 0,
            "total_amount": 0,
            "discount": 0,
            "is_gift": true
        }
    ]
}
```