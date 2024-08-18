# WebAPI com MySQL 
#### Iremos Instalar os seguintes pacotes: 

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- MySql.EntityFrameworkCore
- Pomelo.EntityFrameworkCore.MySql

Para fazer a conexão com o banco de dados, teremos que colocar uma string de conexão com o nome ConnectionStrings com valor da ConexaoPadrao(qualquer nome) dentro da appsettings.json



## MySQL conexão com o EntityFrameworkCore

| Parâmetro   | Nome Da String       | Valor                           |
| :---------- | :--------- | :---------------------------------- |
| `ConnectionStrings` | `ConexaoPadrao` | "server=127.0.0.1;uid=User;pwd=Senha;database=BancoDeDados" |



## No código dentro da appsettings.json:

```json
  {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "ConexaoPadrao": "server=127.0.0.1;uid=User;pwd=Senha;database=BancoDeDados"
  },
  "AllowedHosts": "*"
}
```

## Criamos AppDBContext responsável para conexão com o Banco De Dados
```C#
public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }     
}
```

Após isso criaremos de vez a conexão no **Program.cs**
# MySQL conexão com o EntityFrameworkCore
## No Program.cs:

```C#
builder.Services.AddDbContextPool<AppDBContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("ConexaoPadrao"), 
optionsMysql => MySqlServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoPadrao"))));
var app = builder.Build();

```
ConexaoPadrao = Nossa String de conexão do **appsettings.json**  






| Item                                                                                     | Explicação                                                                                         |
| ---------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------- |
| `ConexaoPadrao`                                                                          | String de conexão padrão                                                                           |
| `optionsMysql => MySqlServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoPadrao"))` | Lambda com o AutoDetect do Pomelo para passar a versão do banco de dados usando também a `ConexaoPadrao` |



## Autores

- [@Zarby009](https://www.github.com/Zarby009)

