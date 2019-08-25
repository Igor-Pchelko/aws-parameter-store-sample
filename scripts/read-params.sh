CHAMBER_KMS_KEY_ALIAS=aws/ssm
AWS_REGION=us-east-1

echo "Platform generic:" 
chamber export sample-platform/development | jq 

echo "Service specific:" 
chamber export sample-platform/account-service/development | jq

echo "Aggregated result:" 
chamber export sample-platform/development sample-platform/account-service/development | jq
