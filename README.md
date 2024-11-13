# Projeto Prático em Sistemas - Estética Automotiva Schutzen

## Descrição

Este projeto consiste em uma aplicação de estética automotiva desenvolvida para facilitar a gestão de serviços de cuidado automotivo. Os clientes podem visualizar os serviços disponíveis, realizar o agendamento de serviços específicos para seus veículos e gerenciar o histórico de agendamentos. O sistema foi desenvolvido utilizando **ASP.NET Core MVC**, **C#** e **Entity Framework Core** para manipulação de dados e controle de usuários.

## Funcionalidades

- **Cadastro e Login de Usuários**: Clientes podem criar uma conta e fazer login para acessar os serviços oferecidos.
- **Apresentação de Serviços**: Exibição de uma lista de serviços automotivos, como lavagem detalhada, polimento, higienização, entre outros.
- **Agendamento de Serviços**: Permite ao cliente escolher o tipo de serviço e agendar o dia e horário desejado.
- **Gestão de Veículos**: O cliente pode cadastrar diferentes veículos (SUV, Hatch, Sedan) para associar com os serviços de agendamento.
- **Histórico de Agendamentos**: O cliente pode acessar o histórico de serviços realizados.

## Tecnologias Utilizadas

- **ASP.NET Core MVC 8**: Para a estruturação do sistema e criação do backend.
- **C#**: Linguagem de programação utilizada para desenvolver as funcionalidades e a lógica do sistema.
- **Entity Framework Core**: Para o mapeamento de dados e manipulação de informações no banco de dados.
- **SQL Server**: Utilizado como banco de dados para armazenamento de dados dos usuários, veículos e agendamentos.
- **Bootstrap**: Para estilização e responsividade da interface.

## Estrutura do Projeto

- `Controllers`: Contém os controladores responsáveis pela lógica de negócio.
- `Models`: Armazena as classes de modelo de dados e entidades.
- `Views`: Contém as páginas da aplicação, como login, cadastro, agendamento e histórico de serviços.
- `UIModels`: Contém os modelos de visualização (view models) que permitem a comunicação entre as Views e os Controllers.
- `wwwroot`: Diretório para recursos estáticos, como imagens e estilos CSS.
