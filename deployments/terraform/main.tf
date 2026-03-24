terraform {
  required_version = ">= 1.8.0"

  required_providers {
    google = {
      source  = "hashicorp/google"
      version = "~> 6.0"
    }
  }
}

provider "google" {}

variable "project_id" {
  description = "GCP project id"
  type        = string
}

resource "google_cloud_run_v2_service" "api" {
  name     = "sdlc-automation-api"
  location = "us-central1"

  template {
    containers {
      image = "gcr.io/${var.project_id}/sdlc-automation-api:latest"
    }
  }
}
