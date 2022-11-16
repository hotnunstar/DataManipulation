# Trabalho Prático 1 de Integração de Sistemas de Informação

Para começar, executar o projeto desenvolvido em C#. O dataset de entrada está armazenado do diretório "Files/csv_files"
Em seguida, deverão ser executadas três tarefas distintas, sendo elas:
1. Abrir o respetivo projeto **.ktr** no software *Pentaho Data Integration*
2. Executar o *MQTT subscriber*
3. Executar o *node-red* e importar as configurações armazenadas no ficheiro **.json**

Após a execução das tarefas anteriormente descritas, o *kettle* deverá ser colocado a correr. Com isto,
1. Será gerado um ficheiro resultante da conversão do **.json** para **.xml**
2. Se existir uma conexão à *MongoDB*, serão geradas as respetivas tabelas resultantes das filtrações implementadas no *kettle*
3. Na dashboard do *node-red* serão apresentadas diversas informações relevantes à cerca do dataset utilizado como *input* no projeto de C#

Na dashboard do *node-red*, há também a possibilidade de inserir manualmente um chip. Estes dados são armazenados diretamente na base de dados, numa tabela onde constam apenas os chips inseridos pelo utilizador.
