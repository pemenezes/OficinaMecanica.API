🛠 Projeto Prático .NET - Oficina Mecânica
Este repositório contém o projeto de Prova Prática de Desenvolvimento Web .NET, implementando uma API de Gestão para Oficina Mecânica utilizando ASP.NET Core, Entity Framework Core e o banco de dados Oracle.

O projeto atende aos requisitos de CRUD obrigatórios, implementação de login e regras de negócio específicas do tema.

👥 Integrantes
Integrante 1: [Pedro henrique menezes mariano silva] (Referência do Tema M-P)

Integrante 2: [Augusto]

🔧 Tema e Entidades
Tema: Oficina Mecânica (Grupo M-P)

Entidades Implementadas: Cliente, Produto, Funcionário, Fornecedor, OrdemDeServico, Agendamento.

Regras de Negócio Implementadas
Ordem de Serviço (OS): Uma OS com status "Concluída" não pode ser editada via API.

Agendamento: A API impede o choque de horários (sobreposição de datas/horas) para o mesmo mecânico (Funcionario).

🚀 Passo a Passo para Execução (Rápida!)
Siga estes passos para configurar e testar a API.

1. Pré-requisitos
Visual Studio 2022 (ou superior).

SDK .NET 8.0 (ou a versão que você usou, ex: .NET 6.0/7.0).

Banco de Dados Oracle acessível (o projeto usará a Connection String definida).

2. Configuração da Conexão Oracle
Antes de compilar, você deve configurar o acesso ao seu banco de dados:

Abra o arquivo appsettings.json na pasta raiz do projeto OficinaMecanica.API.

Substitua o valor de OracleConnection pela sua string de conexão real:

JSON

"ConnectionStrings": {
    "OracleConnection": "DATA SOURCE=seu_servidor_oracle:porta/seu_servico;USER ID=seu_usuario;PASSWORD=sua_senha"
}
3. Execução do Projeto
Basta rodar a aplicação no Visual Studio.

Abra a Solution (OficinaMecanica.sln).

Verifique se o projeto OficinaMecanica.API está definido como Projeto de Inicialização.

Pressione F5 (ou o botão Run/Executar) no Visual Studio.

O navegador abrirá automaticamente a interface Swagger/OpenAPI.

🧪 Testando a API e as Regras
Use a interface Swagger para validar o CRUD completo e as regras de negócio:

1. Login (Validação de Acesso)
Endpoint: /api/Login (POST)

Teste: Use um usuário Funcionário pre-cadastrado no seu banco para simular o Login. Um retorno 200 OK valida a funcionalidade.

2. Teste de CRUD Obrigatório (Cliente)
Endpoint: /api/Clientes

Teste: Execute o POST para criar um novo cliente e o GET para listar, validando o CRUD obrigatório.

3. Teste da Regra de Negócio: Choque de Agendamento
Agendamento 1 (POST): Agende um serviço para o Mecânico ID 1 das 10:00 às 11:00.

Agendamento 2 (POST): Tente agendar um novo serviço para o MESMO Mecânico ID 1 no período das 10:30 às 11:30.

Resultado Esperado: A API deve retornar um código 409 Conflict ou 400 Bad Request com a mensagem de que o horário está ocupado.

4. Teste da Regra de Negócio: OS Concluída
Ordem de Serviço (POST): Crie uma nova OS com Status: "Aberta".

Atualização (PUT): Atualize a OS, mudando o Status para "Concluída".

Tentativa de Edição (PUT): Tente executar o PUT novamente, mudando qualquer outro campo (ex: Observacoes).

Resultado Esperado: A API deve retornar 400 Bad Request (ou similar) com a mensagem de erro: "OS concluída não pode ser editada."
