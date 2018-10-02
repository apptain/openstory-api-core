using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace OpenStory.Api.Sagas
{
  public static class Utils
  {
    public static string ContentTypeApplicationJson { get; private set; }

    public static BrokeredMessage CreateForwardMessage(BrokeredMessage message, dynamic entity, string via)
    {
      var brokeredMessage = new BrokeredMessage(SerializeEntity(entity))
      {
        ContentType = ContentTypeApplicationJson,
        Label = message.Label,
        TimeToLive = message.ExpiresAtUtc - DateTime.UtcNow
      };
      foreach (var prop in message.Properties)
      {
        brokeredMessage.Properties[prop.Key] = prop.Value;
      }
      brokeredMessage.Properties["Via"] = via;
      return brokeredMessage;
    }

    public static MemoryStream SerializeEntity(dynamic entity)
    {
      return new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(entity)));
    }

    public static T DeserializeEntity<T>(Stream body)
    {
      return JsonConvert.DeserializeObject<T>(new StreamReader(body, true).ReadToEnd());
    }

  }
}
