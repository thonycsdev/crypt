# Verifica se um nome foi passado como argumento
if [ -z "$1" ]; then
  echo "Uso: $0 [NOME]"
  exit 1
fi

# Executa o comando com o nome fornecido
dotnet ef migrations add "$1" --startup-project ../Crypt.API/
