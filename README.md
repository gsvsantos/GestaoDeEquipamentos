# Gestao De Equipamentos
Um simples programa que permite registrar, listar, editar e excluir equipamentos e chamados de manunteção.

![](https://i.imgur.com/z246mOI.gif)

## Diagrama do Projeto
Planejamento do projeto no Whimsical: [Atividade - Gestão de Equipamentos](https://whimsical.com/atividade-gestao-de-equipamentos-EFv5bntPie38qufMixdGjg)

## Como Usar
1. O usuário navega pelo menu principal, podendo escolher entre gerenciar **equipamentos** ou **chamados**.
2. Menu de equipamentos contém:
   - Registrar Equipamento
   - Consultar Equipamentos
   - Editar Equipamento
   - Remover Equipamento
3. Menu de chamados contém:
   - Criar Chamado
   - Consultar Chamados
   - Editar Chamado
   - Encerrar Chamado

*O programa valida as entradas para garantir que os dados inseridos estejam corretos.*

## Estrutura do Projeto
O projeto está organizado na seguinte forma:

- **[Program.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Program.cs)**: Arquivo principal, nele contém o necessário para inicializar e executar o programa.
- **[Entities/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/master/GestaoDeEquipamentos.ConsoleApp/Entities)**
  - **[Entity.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/Entity.cs)**: Serve como base para lidar com os ids das classes Equipment.cs e MaintenanceRequest.cs.
  - **[Equipment.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/Equipment.cs)**: Contém os atributos e método dos equipamentos.
  - **[EquipmentManager.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/EquipmentManager.cs)**: Serve para o gerenciamento geral dos equipamentos.
  - **[MaintenanceRequest.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/MaintenanceRequest.cs)**: Contém os atributos e método dos chamados.
  - **[MaintenanceRequestManager.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/MaintenanceRequestManager.cs)**: Serve para o gerenciamento geral dos chamados.
- **[Entities/Utils/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/master/GestaoDeEquipamentos.ConsoleApp/Entities/Utils)**
  - **[ShowMenu.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/Utils/ShowMenu.cs)**: Lida com as impressões dos menus no console.
  - **[Validators.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/Utils/Validators.cs)**: Lida com as as validações gerais dos inputs do usuário.
  - **[ViewColors.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/Utils/ViewColors.cs)**: Lida com a coloração das impressões no console.
  - **[ViewErrors.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/Utils/ViewErrors.cs)**: Lida com as impressões de mensagens de erros.
  - **[ViewUtils.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/Utils/ViewUtils.cs)**: Lida com as impressões das interações com o usuário.
  - **[ViewWrite.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/master/GestaoDeEquipamentos.ConsoleApp/Entities/Utils/ViewWrite.cs)**: Lida com impressões de gerais no console.
 
## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
 
## Tecnologias

[![Tecnologias](https://skillicons.dev/icons?i=git,github,visualstudio,cs,dotnet)](https://skillicons.dev)

## Como Utilizar
1. **Clone o Repositório:**
```
git clone https://github.com/gsvsantos/GestaoDeEquipamentos.git
```

2. Abra o terminal ou prompt de comando e navegue até a pasta raiz do programa.

3. Utilize o comando abaixo para restaurar as dependências do projeto.
```
dotnet restore
```

4. Compile e execute o arquivo *.exe* do programa.
```
dotnet build --configuration Release
```
```
GestaoDeEquipamentos.ConsoleApp.exe
```

### Opcional
- Executar o projeto compilando em tempo real
```
dotnet run --project GestaoDeEquipamentos.ConsoleApp
```

# Sobre o Projeto

Este projeto foi desenvolvido como parte de um trabalho da [Academia do Programador](https://www.instagram.com/academiadoprogramador/).
