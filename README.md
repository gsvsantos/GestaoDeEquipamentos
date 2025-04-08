# Gestao De Equipamentos
Um simples programa que permite registrar, listar, editar e excluir equipamentos e chamados de manunteção.

## Diagrama do Projeto
Planejamento do projeto no Whimsical: [Atividade - Gestão de Equipamentos v1](https://whimsical.com/atividade-gestao-de-equipamentos-EFv5bntPie38qufMixdGjg)   
*versão atual não consta no planejamento no Whimsical!*

## Como Usar
1. Menu de equipamentos contém:
   - Gerenciar Equipamentos
   - Gerenciar Chamados
   - Gerenciar Fabricantes
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
3. Menu de fabricantes contém:
   - Cadastrar Fabricante
   - Consultar Fabricantes
   - Editar Fabricante
   - Deletar Fabricante

*O programa valida as entradas para garantir que os dados inseridos estejam corretos.*

## Estrutura do Projeto
O projeto está organizado na seguinte forma:

- **[Compartilhado/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/v2/GestaoDeEquipamentos.ConsoleApp/Compartilhado)** Contém classes auxiliares e compartilhadas pelo sistema.  
  - **[Entidade.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Compartilhado/Entidade.cs)**: Serve como base para lidar com os IDs das classes Equipamento.cs e Chamado.cs.
  - **[TelaPrincipal.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Compartilhado/TelaPrincipal.cs)**: Lida com as impressões dos menus no console.
  - **[Validador.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Compartilhado/Validador.cs)**: Lida com as validações gerais dos inputs do usuário.
  - **[VisualizacaoCores.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Compartilhado/VisualizacaoCores.cs)**: Lida com a coloração das impressões no console.
  - **[VisualizacaoErros.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Compartilhado/VisualizacaoErros.cs)**: Lida com as impressões de mensagens de erros.
  - **[UtilitariosVisualizacao.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Compartilhado/UtilitariosVisualizacao.cs)**: Lida com a entrada de dados do usuário e imprime mensagens interativas no console.
  - **[EscritaVisualizacao.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Compartilhado/EscritaVisualizacao.cs)**: Lida com impressões gerais no console.

- **[ModuloEquipamento/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/v2/GestaoDeEquipamentos.ConsoleApp/ModuloEquipamento)** Contém arquivos relacionados aos equipamentos.  
  - **[Equipamento.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/ModuloEquipamento/Equipamento.cs)**: Contém os atributos e métodos dos equipamentos.
  - **[TelaEquipamento.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/ModuloEquipamento/TelaEquipamento.cs)**: Responsável pela interface do usuário relacionada a equipamentos.
  - **[RepositorioEquipamento.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/ModuloEquipamento/RepositorioEquipamento.cs)**: Gerencia os dados dos equipamentos.

- **[ModuloChamado/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/v2/GestaoDeEquipamentos.ConsoleApp/ModuloChamado)** Contém arquivos relacionados aos chamados.  
  - **[Chamado.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/ModuloChamado/Chamado.cs)**: Contém os atributos e métodos dos chamados.
  - **[TelaChamado.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/ModuloChamado/TelaChamado.cs)**: Responsável pela interface do usuário relacionada a chamados.
  - **[RepositorioChamado.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/ModuloChamado/RepositorioChamado.cs)**: Gerencia os dados dos chamados.

- **[ModuloFabricante/](https://github.com/gsvsantos/GestaoDeEquipamentos/tree/v2/GestaoDeEquipamentos.ConsoleApp/ModuloFabricante)** Contém arquivos relacionados aos fabricantes.  
  - **[Fabricante.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/ModuloFabricante/Fabricante.cs)**: Contém os atributos e métodos dos fabricantes.
  - **[TelaFabricante.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/ModuloFabricante/TelaFabricante.cs)**: Responsável pela interface do usuário relacionada a fabricantes.
  - **[RepositorioFabricante.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/ModuloFabricante/RepositorioFabricante.cs)**: Gerencia os dados dos fabricantes.

- **[Program.cs](https://github.com/gsvsantos/GestaoDeEquipamentos/blob/v2/GestaoDeEquipamentos.ConsoleApp/Program.cs)**: Arquivo principal, contém o necessário para inicializar e executar o programa.


 
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

Este projeto foi desenvolvido como parte de uma atividade da [Academia do Programador](https://www.instagram.com/academiadoprogramador/).
