# UserProductAPI

<img src="https://github.com/murilloliveiraz/UserProductAPI/blob/main/Images/header.png" alt="Imagem do Projeto">

> API criada para aplicar meus estudos sobre o Identity e Entity do .NET

### Ajustes e melhorias

A ideia inicial do projeto já foi concluida mas estou aberto a conselhos sobre melhorias, e pretendo aplicar conceitos novos nele conforme eu for aprendendo e estudando.

## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:

- Você instalou a versão mais recente do `<.NET/>`
- Você tem uma máquina `<Windows>`.

## 🚀 Instalando UserProductAPI

Para instalar a UserProductAPI, siga estas etapas:


Windows:

```
<git clone https://github.com/murilloliveiraz/UserProductAPI>
```

## ☕ Usando UserProductAPI

Para usar UserProductAPI, siga estas etapas:

```
abra a pasta do projeto no terminal
digite "dotnet run"
uma nova janela vai ser aberta e voce terá o projeto rodando localmente na sua máquina
```

## Endpoints

| Endpoints (principais)  | Parâmetros do Body (json)                                | Método      | Explicação                    | Parâmetros do Head (Token)      
| ------------------------| ---------------------------------------------------------|-------------|-------------------------------|----------------------------------
|/users/signup            | username, role, password, rePassword                     | POST        |Cadastra um user               | Nenhum
|/users/login             | username, password                                       | POST        |Loga um user                   | Nenhum 
|/products                | Nenhum                                                   | GET         |Mostra "todos" os produtos     | Nenhum
|/produtos/id             | Nenhum                                                   | GET         |Mostra um produto específico   | Nenhum
|/products                | name, description, price                                 | POST        |Cria um produto                | Token JWT gerado após o Login
|/products/id             | name, description, price                                 | PUT         |Atualiza um produto especifíco | Nenhum
|/products/id             | Nenhum                                                   | DELETE      |Deleta um produto              | Token JWT gerado após o Login

## 🤝 Colaboradores

Agradecemos às seguintes pessoas que contribuíram para este projeto:

<table>
  <tr>
    <td align="center">
      <a href="#" title="defina o titulo do link">
        <img src="https://avatars.githubusercontent.com/u/113298979?v=4936044" width="100px;" alt="Foto do Murillo no GitHub"/><br>
        <sub>
          <b>Iuri Silva</b>
        </sub>
      </a>
    </td>
  </tr>
</table>
