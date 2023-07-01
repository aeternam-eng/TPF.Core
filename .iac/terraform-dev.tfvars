resource_group_config = {
  location = "brazilsouth"
  name     = "rg-stronzo-tapegandofogo"
}

service_config = {
  name     = "stronzo-tapegandofogo-core"
  shortEnv = "dev"
}

appserviceplan_config = {
  os_type  = "Linux"
  sku_name = "F1"
}
