# Examples.SenderConsumer

This is the example of the commands sender and consumer. If don't familiar with commands sending concept in Masstransit, read [this](https://masstransit-project.com/usage/producers.html#send) article
In Swisschain services it's common to send commands only within the single service from the API host to the worker host.

In this particular example API sends `ExecuteWithdrawal` command whenever `POST /api/withdrawals/execute` is called and worker consumes this command.