# Examples.Publisher

This is the example of the events publisher. If don't familiar with events publishing concept in Masstransit, read [this](https://masstransit-project.com/usage/producers.html#publish) article
Events can be published by both API and Worker services. 

In this particular example API publishes `IsAliveTriggered` event whenever `/api/isalive` is called and Worker publishes event `TimeIsOut` every 10 seconds.