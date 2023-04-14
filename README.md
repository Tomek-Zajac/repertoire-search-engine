# repertoire-search-engine
To run infrastructure:
docker-compose -f "./compose/Infrastructure/docker-compose.yml" -f "./compose/Infrastructure/docker-compose.override.yml" up -d

To run repertoiresearchengine:
docker-compose -f "./compose/RepertoireSearchEngine/docker-compose.yml" -f "./compose/RepertoireSearchEngine/docker-compose.override.yml" up -d
