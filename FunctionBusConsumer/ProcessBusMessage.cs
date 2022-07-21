using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FunctionBusConsumer
{
    public static class ProcessBusMessage
    {
        [FunctionName("ProcessBusMessage")]
        public static Task Run(
        [ServiceBusTrigger("SampleType", Connection = "BusCns")]
        string myQueueItem,
        int deliveryCount,
        DateTime enqueuedTimeUtc,
        string messageId,
        ILogger log,
        [SignalR(HubName = "notification", ConnectionStringSetting = "HubCns")] IAsyncCollector<SignalRMessage> signalRMessages)
        {

            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            log.LogInformation($"DeliveryCount={deliveryCount}");
            log.LogInformation($"MessageId={messageId}");

            System.Threading.Thread.Sleep(5000);


            return signalRMessages.AddAsync(
                new SignalRMessage
                {
                    Target = "ClientNotificationMethod",
                    Arguments = new[] { "SampleType", "SampleType processado com Sucesso." }
                });

        }
    }
}
