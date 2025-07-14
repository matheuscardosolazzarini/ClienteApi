# API de Clientes e Pedidos

Este é o projeto backend de uma API RESTful desenvolvida em C# com .NET 8 para gerenciar clientes e seus respectivos pedidos. A API foi construída utilizando Entity Framework Core para acesso a dados e Swagger para documentação interativa.

## Pré-requisitos

Antes de começar, você precisará ter o seguinte software instalado em sua máquina:

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) com a carga de trabalho "Desenvolvimento ASP.NET e Web".
    * *Alternativamente, você pode usar o [Visual Studio Code](https://code.visualstudio.com/) com a extensão C#.*
* SQL Server (A aplicação está configurada por padrão para usar o **SQL Server Express LocalDB**, que é instalado junto com o Visual Studio).

## ⚙️ Configuração do Projeto

Siga os passos abaixo para configurar o ambiente de desenvolvimento local.

1.  **Clone o Repositório**
    cd ClienteApi
    ``` '''
     git clone https://github.com/matheuscardosolazzarini/ClienteApi.git

2.  **Abra o Projeto**
    * **No Visual Studio:** Abra o arquivo da solução (`ClienteApi.sln`).
    * **No VS Code:** Abra a pasta do projeto (`ClienteApi`).

3.  **Verifique a String de Conexão**
    * A API está configurada para usar o SQL Server LocalDB. A string de conexão pode ser encontrada no arquivo `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ClienteApiDb;Trusted_Connection=True;"
    }
    ```
    * Se você estiver usando uma instância diferente do SQL Server, atualize esta string de conexão.

4.  **Crie o Banco de Dados (Migrations)**
    * As "Migrations" do Entity Framework já estão no projeto. Elas são como um script que ensina o EF Core a criar o banco de dados exatamente como nossas classes C#. Para executar esse script, faça o seguinte:
    * **No Visual Studio:**
        1.  Vá para o menu **Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciador de Pacotes**.
        2.  No console que se abre, execute o seguinte comando:
        ```powershell
        Update-Database
        ```
    * Este comando irá ler os arquivos na pasta `Migrations` e criar o banco de dados `ClienteApiDb` com todas as tabelas e relacionamentos que definimos.

## ▶️ Executando a Aplicação

Com o banco de dados configurado, você pode executar a API de duas maneiras:

* **Pelo Visual Studio:**
    * Simplesmente pressione `F5` ou clique no botão de play (▶️ `https://localhost...`) na barra de ferramentas.

* **Pela Linha de Comando:**
    * Navegue até a pasta raiz do projeto no seu terminal e execute:
    ```bash
    dotnet run
    ```

## 🧪 Testando a API com Swagger

Após iniciar a aplicação, uma janela do navegador será aberta automaticamente com a interface do Swagger.

* **URL:** `https://localhost:<PORTA>/swagger/index.html` (A porta é definida no arquivo `Properties/launchSettings.json`).

O Swagger fornece uma documentação completa e interativa de todos os endpoints disponíveis, como o `GET /api/clientes` para listar todos os clientes. Você pode usar essa interface para testar todas as funcionalidades de `GET`, `POST`, `PUT` e `DELETE` diretamente do seu navegador.﻿
