# 🧩 Sprint4.CSharp.WebApi (ASP.NET Core + EF Core + Swagger )

## Alunos
-  Camila do Prado Padalino – **RM98316**  
- Felipe  Cavalcante Bressane – **RM97688**  
- Gabriel  Teixeira Machado – **RM551570**  
-  Guilherme Brazioli – **RM98237**

## Entrega da ** Sprint 4 – C# ** com os itens do anunciado
-  ** ASP.NET Core Web API + Entity Framework Core com CRUD completo **  
  -  ` ProdutosController` com ** Criar/Leitura/Atualizar/Excluir ** e relacionamento ` Produto → Categoria` .  
  - Banco ** SQLite ** criado automaticamente com * seed * inicial.
-  ** Pesquisas com LINQ **  
  -  ` LinqController` com ** busca por nome ** , ** Top N por preço ** e ** paginação ** .
-  ** Documentação do projeto **  
  -  ** Swagger ** habilitado na raiz da aplicação + comentários XML.  
  -  ** README ** (este arquivo) e coleção ** Postman ** para testes.
-  ** Arquitetura em diagramas **  
  - Diagrama em ** Sereia ** ( ` /Diagrams/arquitetura.md ` ).

---

## Como rodar
1 .  ** Pré-requisitos: **  ` dotnet 8 SDK ` .  
2 . Abra a   pasta do projeto ` Sprint4.CSharp.WebApi` .
3. Restaure e compile :
   ``` festança
   restauração dotnet
   construção dotnet
   ```
4. Executar :
   ``` festança
   dotnet run
   ```
5 . Acesse o ** Swagger ** na raiz (ex.: ` http://localhost:5000 ` ou ` https://localhost:5001 ` ).  
   > O arquivo ** SQLite **  ` app.db ` é criado automaticamente na primeira execução.
---

## Uso rápido (via Swagger)
1. Abra o ** Swagger UI ** .  
2 . Em ** /api/products ** :
   -  ` POST ` para criar um produto (use um ` CategoryId ` existente).  
   -  ` GET ` para listar, ` GET {id} ` para detalhes, ` PUT {id} ` para atualizar e ` DELETE {id} ` para remover.
3 . Em ** /api/linq ** :
   -  ` GET /search?term=mouse ` → busca por nome.  
   -  ` GET /top-expensive?take=3 ` → Top N por preço.  
   -  ` GET /paged?page=1&pageSize=2 ` → paginação simples.

---

## Camadas & Responsabilidades
-  ** Modelos ** : entidades ` Produto ` e ` Categoria ` .  
-  ** Dados ** : ` AppDbContext` (EF Core ) + ` Seed` de dados.  
-  ** Repositórios ** : ` EfRepository<T> ` (exemplo de repositório genérico).  
-  ** Controladores ** :  
  -  ` ProdutosController` (CRUD completo ).  
  -  ` LinqController` ( consulta LINQ).  
-  ** Documentos/Diagramas ** : documentação e diagrama de arquitetura (Mermaid).

---

## Estrutura de Pastas
```
Sprint4.CSharp.WebApi/
  Controladores/
    LinqController.cs
    ProdutosController.cs
  Dados/
    AppDbContext.cs
  DTOs/
    ProdutoCriarDto.cs
    ProdutoReadDto.cs
  Modelos/
    Categoria.cs
    Produto.cs
  Repositórios/
    EfRepository.cs
    IRepositório.cs
  Diagramas/
    arquitetura.md
  Carteiro/
    Sprint4_CSharp_Revisado.postman_collection.json
  Programa.cs
  configurações de aplicativo.json
  Sprint4.CSharp.WebApi.csproj
```

## Principais pontos de extremidade

### Produtos (CRUD)
-  ` GET /api/products ` – lista todos (com ` CategoryName ` )  
-  ` GET /api/products/{id} ` – obtidos por ID  
-  ` POST /api/products ` – cria (corpo: ` ProductCreateDto ` )  
-  ` PUT /api/products/{id} ` – atualiza  
-  ` DELETE /api/products/{id} ` – remover

### LINQ
-  ` GET /api/linq/search?term={texto} ` – busca * contém * (sem distinção entre maiúsculas e minúsculas)  
-  ` GET /api/linq/top-expensive?take=3 ` – Top N por preço (desc)  
-  ` GET /api/linq/paged?page=1&pageSize=2 ` – paginação simples
