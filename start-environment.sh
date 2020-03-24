docker network create examples.local

docker run -p 15672:15672 -p 55672:5672 -e RABBITMQ_DEFAULT_USER=examples -e RABBITMQ_DEFAULT_PASS=examples --name rabbit.examples.local --network examples.local rabbitmq:3.6.16-management