variable "resource_location" {
  type = string
}

variable "environment" {
  type = string
}

variable "appserviceplan_config" {
  type = object({
    os_type  = string
    sku_name = string
  })
}
