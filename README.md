# 📱 Projeto: Maui Games

### 🎓 Aluno: Samuel Santos Souza  
**Curso:** DSM – 5º semestre  
**Disciplinas:** Laboratório de Programação para Dispositivos Móveis e Computação em Nuvem I  
**Professor:** Alessandro Fukuta  

---

## 💡 Descrição

Aplicativo mobile desenvolvido em .NET MAUI que permite **cadastrar, listar e excluir jogos**.  
Os dados são armazenados em um **banco de dados MySQL hospedado em uma máquina virtual no Azure**.

---

## 🛠️ Tecnologias Utilizadas

- .NET MAUI (.NET 8)
- C#
- MySQL Server
- Azure Virtual Machine (Linux)
- MySql.Data (pacote NuGet)
- XAML
- Git / GitHub

---

## 🔧 Funcionalidades

- 📥 Cadastro de games (título, plataforma, nota)
- 📃 Listagem de games cadastrados
- 🗑️ Exclusão de registros
- 🔄 Atualização manual da lista
- 🌙 Suporte a tema escuro/claro

---

## 🌐 Banco de Dados (Azure)

- Banco: `gamesdb`  
- Tabela: `games`  
```sql
CREATE TABLE games (
  id INT AUTO_INCREMENT PRIMARY KEY,
  titulo VARCHAR(100),
  plataforma VARCHAR(50),
  nota INT
);
```


📂 Estrutura de Telas
Tela	Descrição
LoginPage	Tela inicial de login
MenuPrincipal	Navegação com abas
CadastroGamePage	Cadastro de games via formulário
Games Cadastrados	Lista com exclusão via botão
Usuário	Página com botão de logout

📦 Como Executar
Clone este repositório:

bash
Copiar
Editar
git clone https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git
Abra no Visual Studio 2022 (com suporte a .NET MAUI)

Restaure os pacotes NuGet (MySql.Data)

Ajuste a string de conexão em:

CadastroGamePage.xaml.cs

MenuPrincipal.xaml.cs

Rode o app no emulador ou dispositivo Android físico

✅ Status
✔️ Projeto finalizado e funcional
✔️ Entregue como avaliação de 2º bimestre nas disciplinas DSM
✔️ Integração com banco em nuvem

