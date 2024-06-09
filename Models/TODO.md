## Prioridades:

- ### Micro serviços utilizando EntityFramework

> #### 1 - Criação de uma API para cada modelo: 
> - [ ] API de Car sendo apenas consumida e englobando a model `Car`
>
> 
> - [ ] API de Service consumindo a de Car englobando as models: `Service`, `Car`
>
> 
> - [ ] API de CarService consumindo a de Car e Service englobando as models: `Service`, `Car`, `CarService`
>
> 
> - [ ] API de Purchase consumindo a de Car englobando as models: `Purchase`, `Car`
>
> 
> - [ ] API de Address consumindo serviço externo dos Correios englobando as models: `Address`
>
> 
> - [ ] API Costumer consumindo a de Address englobando as models: `Person`, `Address`, `Costumer`
>
> 
> - [ ] API Employee consumindo a de Address englobando as models: `Person` , `Address` , `Employee` , `Position`
>
> 
> - [ ] API de Payment englobando as models: `CreditCard`, `Boleto`, `Pix`, `PixType`  
>
> 
> - [ ] API de Sale consumido a de Car, Costumer, Employee e Payment englobando as models: `Sale`, `Car`, `Employee`, `Costumer`, `Payment` 

> #### 2 - Criação das Migrations e Banco de dados:
> - [ ] 

> #### 3 - Criação dos controller e aplicação das regras de negócio:
> - [ ] Inserção de Person (Costumer ou Employee) e inserção do endereço baseado na api dos correios 