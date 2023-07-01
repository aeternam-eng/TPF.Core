provider "azurerm" {
  subscription_id            = var.azurerm_provider_config.subscription_id
  client_id                  = var.azurerm_provider_config.client_id
  client_secret              = var.azurerm_provider_config.client_secret
  tenant_id                  = var.azurerm_provider_config.tenant_id
  skip_provider_registration = true

  features {}
}


terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0.0"
    }
  }

  backend "azurerm" {}
}

resource "azurerm_resource_group" "rg" {
  name     = var.resource_group_name
  location = var.resource_group_location
}

resource "azurerm_service_plan" "appserviceplan" {
  name                = "asp-${var.service_config.name}-${var.service_config.short_env}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  os_type             = var.appserviceplan_config.os_type
  sku_name            = var.appserviceplan_config.sku_name
}

resource "azurerm_linux_web_app" "webapp" {
  name                = "${var.service_config.name}-${var.service_config.short_env}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  service_plan_id     = azurerm_service_plan.appserviceplan.id
  https_only          = true
  site_config {
    minimum_tls_version = "1.2"
  }
}