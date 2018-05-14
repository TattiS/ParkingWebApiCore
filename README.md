# ParkingWebApiCore
### ASP.NET Core Web API додаток на базі проекту Parking project 

Доступ до всього функціоналу реалізований за допомогою WebAPI. 
Для тестування роботи додатка скористалася наступним тулзом: Postman (https://www.getpostman.com/)

REST API:
Cars: Список всіх машин (GET); Деталі по одній машині (GET); Видалити машину (DELETE); Додати машину (POST)

Parking: Кількість вільних місць (GET); Кількість зайнятих місць (GET); Загальний дохід (GET)

Transactions: Вивести Transactions.log (GET); Вивести транзакції за останню хвилину (GET); Вивести транзакції за останню хвилину по одній конкретній машині (GET); Поповнити баланс машини (PUT)

Рішення включає два проекти ParkingLibrary та ParkingWebApi
