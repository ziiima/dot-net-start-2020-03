compose := @docker compose -f compose.yaml
api_container_id = $(shell docker ps --format json --filter name=api_container | jq -r '.ID')

.PHONY: local.up

local.up:
	$(compose) up -d

local.up.build:
	$(compose) up -d --build

local.api.exec:
	@docker exec -it $(api_container_id) bash
