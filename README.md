# Gestao De Equipamentos
Um simples programa que permite registrar, listar, editar e excluir equipamentos e chamados de manunte��o.

## Diagrama do Projeto
Planejamento do projeto no Whimsical: [Atividade - Gest�o de Equipamentos v1](https://whimsical.com/atividade-gestao-de-equipamentos-EFv5bntPie38qufMixdGjg)   
*vers�o 2(atual) n�o consta no planejamento no Whimsical!*

## Como Usar
1. Menu de equipamentos cont�m:
   - Gerenciar Equipamentos
   - Gerenciar Chamados
   - Gerenciar Fabricantes
2. Menu de equipamentos cont�m:
   - Registrar Equipamento
   - Consultar Equipamentos
   - Editar Equipamento
   - Remover Equipamento
3. Menu de chamados cont�m:
   - Criar Chamado
   - Consultar Chamados
   - Editar Chamado
   - Encerrar Chamado
3. Menu de fabricantes cont�m:
   - Cadastrar Fabricante
   - Consultar Fabricantes
   - Editar Fabricante
   - Deletar Fabricante

*O programa valida as entradas para garantir que os dados inseridos estejam corretos.*

## Estrutura do Projeto
O projeto est� organizado na seguinte forma:

- **[Entities/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/v2/GestaoDeEquipamentos.ConsoleApp/Entities)** Cont�m as classes principais que representam os objetos do sistema.  
  - **[Entity.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Entities/Entity.cs)**: Serve como base para lidar com os ids das classes Equipment.cs e MaintenanceRequest.cs.
  - **[Equipment.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Entities/Equipment.cs)**: Cont�m os atributos e m�todo dos equipamentos.
  - **[MaintenanceRequest.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Entities/MaintenanceRequest.cs)**: Cont�m os atributos e m�todo dos chamados.
  - **[Manufacturer.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Entities/Manufacturer.cs)**: Cont�m os atributos e m�todo dos fabricantes.
- **[Managers/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/v2/GestaoDeEquipamentos.ConsoleApp/Managers)** Cont�m a l�gica das opera��es sobre as entidades.  
  - **[EquipmentManager.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Managers/EquipmentManager.cs)**: Serve para o gerenciamento da l�gica dos equipamentos.
  - **[MaintenanceRequestManager.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Managers/MaintenanceRequestManager.cs)**: Serve para o gerenciamento da l�gica dos chamados.
  - **[ManufacturerManager.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Managers/ManufacturerManager.cs)**: Serve para o gerenciamento da l�gica dos fabricantes.
- **[Repositories/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/v2/GestaoDeEquipamentos.ConsoleApp/Managers)** Cont�m a l�gica do gerenciamento dos dados das entidades.  
  - **[EquipmentRepository.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Repositories/EquipmentRepository.cs)**: Serve para o gerenciamento dos dados dos equipamentos.
  - **[MaintenanceRequestRepository.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Repositories/MaintenanceRequestRepository.cs)**: Serve para o gerenciamento dos dados dos equipamentos.
  - **[ManufacturerRepository.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Repositories/ManufacturerRepository.cs)**: Serve para o gerenciamento dos dados dos equipamentos.
- **[UI/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/v2/GestaoDeEquipamentos.ConsoleApp/UI)** Cont�m os arquivos respons�veis pela **interface do usu�rio** no console.  
  - **[ShowMenu.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/UI/ShowMenu.cs)**: Lida com as impress�es dos menus no console.
  - **[ViewColors.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/UI/ViewColors.cs)**: Lida com a colora��o das impress�es no console.
  - **[ViewErrors.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/UI/ViewErrors.cs)**: Lida com as impress�es de mensagens de erros.
  - **[ViewUtils.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/UI/ViewUtils.cs)**: Lida com a entrada de dados do usu�rio e imprime mensagens interativas no console.
  - **[ViewWrite.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/UI/ViewWrite.cs)**: Lida com impress�es de gerais no console.
- **[Utils/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/v2/GestaoDeEquipamentos.ConsoleApp/Utils)** Cont�m fun��es auxiliares.  
  - **[Validators.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Utils/Validators.cs)**: Lida com as valida��es gerais dos inputs do usu�rio.
- **[Program.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Program.cs)**: Arquivo principal, nele cont�m o necess�rio para inicializar e executar o programa.
 
## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.
 
## Tecnologias

[![Tecnologias](https://skillicons.dev/icons?i=git,github,visualstudio,cs,dotnet)](https://skillicons.dev)

## Como Utilizar
1. **Clone o Reposit�rio:**
```
git clone https://github.com/gsvsantos/GestaoDeEquipamentos.git
```

2. Abra o terminal ou prompt de comando e navegue at� a pasta raiz do programa.

3. Utilize o comando abaixo para restaurar as depend�ncias do projeto.
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

Este projeto foi desenvolvido como parte de uma atividade da [Academia do Programador](https://www.instagram.com/academiadoprogramador/).
