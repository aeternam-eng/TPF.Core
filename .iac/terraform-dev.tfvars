locals {
  resource_group_config = {
    location = "brazilsouth"
    name     = "rg-stronzo-tapegandofogo-${var.service_config.shortEnv}"
  }

  appserviceplan_config = {
    os_type  = "Linux"
    sku_name = "F1"
  }
}
