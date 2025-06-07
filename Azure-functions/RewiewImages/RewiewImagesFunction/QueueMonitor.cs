using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace RewiewImagesFunction;

public class QueueMonitor
{
    private readonly ILogger<QueueMonitor> _logger;

    public QueueMonitor(ILogger<QueueMonitor> logger)
    {
        _logger = logger;
    }

    [Function(nameof(QueueMonitor))]
    public void Run([QueueTrigger("review-avatars", Connection = "FranchiseStorage")] QueueMessage message)
    {
        _logger.LogInformation("C# Queue trigger function processed: {messageText}", message.MessageText);
    }
}