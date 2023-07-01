azurerm_provider_config = {
  subscription_id = "#{AzureSubscriptionId}#"
  client_id       = "#{AzureSvcAccountClientId}#"
  client_secret   = "#{AzureSvcAccountClientSecret}#"
  tenant_id       = "#{AzureTenantId}#"
}

tf_backend_config = {
  storage_account_name = "sa-stronzo-iac"
  container_name       = "tfstates"
  key                  = "${var.service_config.short_env}${var.service_config.name}.tfstate"
  access_key           = "#{IaCStorageAccountKey}#"
}
