// Injected from pipeline
provider "azurerm" {
  features {}
}

terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0.0"
    }
  }

  // Injected from pipeline
  backend "azurerm" {}
}

module "conventions" {
  source      = "https://sastronzo.blob.core.windows.net/terraform-modules/naming-conventions.zip"
  environment = var.resource_config.environment
  namespace   = var.resource_config.namespace
  appName     = var.resource_config.name
}

resource "azurerm_postgresql_flexible_server" "databaseserver" {
  name = module.conventions.app_config.database_name

  resource_group_name = module.conventions.resource_group_name
  location            = var.resource_config.location

  sku_name   = "B_Standard_B1ms"
  version    = "13"
  storage_mb = 32768

  backup_retention_days = 7

  administrator_login    = "stronzo"
  administrator_password = "stronzo"
  zone                   = "3"
}

resource "azurerm_storage_account" "storageaccount" {
  name                     = "satpfcore${var.resource_config.environment}"
  resource_group_name      = module.conventions.resource_group_name
  location                 = var.resource_config.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_container" "storagecontainer" {
  name                  = "fire-images"
  storage_account_name  = azurerm_storage_account.storageaccount.name
  container_access_type = "blob"
}

resource "azurerm_service_plan" "appserviceplan" {
  name                = module.conventions.app_config.app_service_plan_name
  location            = var.resource_config.location
  resource_group_name = module.conventions.resource_group_name
  os_type             = var.appserviceplan_config.os_type
  sku_name            = var.appserviceplan_config.sku_name
}

resource "azurerm_linux_web_app" "webapp" {
  name                = module.conventions.app_config.web_app_name
  location            = azurerm_service_plan.appserviceplan.location
  resource_group_name = module.conventions.resource_group_name
  service_plan_id     = azurerm_service_plan.appserviceplan.id
  https_only          = true

  site_config {
    minimum_tls_version = "1.2"
    always_on           = false
    application_stack {
      dotnet_version = "6.0"
    }
  }

  connection_string {
    name  = DefaultConnection
    type  = PostgreSQL
    value = "User ID=stronzo;Password=${azurerm_postgresql_flexible_server.databaseserver.admin_password};Host=${azurerm_postgresql_flexible_server.databaseserver.fully_qualified_domain_name};Port=5432;Database=postgres;Include Error Detail=true"
  }
}
