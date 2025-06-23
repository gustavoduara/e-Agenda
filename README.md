# e-Agenda

[GIF DE DEMONSTRAÇÃO]

## Introdução

E-Agenda é uma aplicação web desenvolvida para gerenciar atividades pessoais e profissionais de forma organizada e eficiente. O sistema permite o controle completo de compromissos, tarefas, contatos e despesas. Oferecendo uma interface intuitiva para o gerenciamento do dia a dia.

## Funcionalidades

O sistema conta com os seguintes módulos principais:

### 1. Gerenciamento de Contatos

- Cadastrar novo contato
- Editar informações do contato
- Excluir contato
- Visualizar lista de contatos

### 2. Controle de Compromissos

- Agendar novo compromisso
- Editar detalhes do compromisso
- Excluir compromisso
- Visualizar agenda de compromissos

### 3. Gerenciamento de Categorias

- Cadastrar nova categoria
- Editar dados da categoria
- Excluir categoria
- Visualizar lista de categorias
- Visualizar despesas de cada categoria

### 4. Controle de Despesas

- Registrar nova despesa
- Editar informações da despesa
- Excluir despesa
- Visualizar histórico de despesas
- Categorizar despesas

### 5. Controle de Tarefas

- Criar nova tarefa
- Editar tarefa existente
- Marcar tarefa como concluída
- Excluir tarefa
- Visualizar lista de tarefas pendentes e concluídas

## Arquitetura

O projeto segue uma arquitetura em camadas:

- **e-Agenda.Dominio**: Contém as entidades de domínio e regras de negócio
- **e-Agenda.Infraestrutura.Arquivos**: Implementa a persistência de dados em arquivos
- **e-Agenda.WebApp**: Camada de apresentação web (MVC)

## Tecnologias

[![Tecnologias](https://skillicons.dev/icons?i=git,github,visualstudio,cs,dotnet,html,css,js,bootstrap)](https://skillicons.dev)

- **Backend**: C# .NET
- **Frontend**: HTML, CSS, JavaScript, Bootstrap
- **Arquitetura**: ASP.NET Core MVC
- **Persistência**: Sistema de arquivos

## Requisitos

- .NET 8.0 ou superior
- Sistema operacional compatível com .NET (Windows, macOS, Linux)
- Navegador web moderno

## Como utilizar

1. Clone o repositório ou baixe o código fonte.
2. Abra o terminal ou o prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as dependências do projeto.

```
dotnet restore
```

4. Em seguida, compile a solução utilizando o comando:

```
dotnet build --configuration Release
```

5. Para executar o projeto compilando em tempo real

```
dotnet run --project e-Agenda.WebApp
```

6. Abra o navegador e acesse:

```
https://localhost:5001
```

ou

```
http://localhost:5000
```
