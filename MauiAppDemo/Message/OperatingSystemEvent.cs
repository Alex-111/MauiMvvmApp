using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiAppDemo.Message;

public sealed class OperatingSystemEvent(OperatingSystemEventType value) : ValueChangedMessage<OperatingSystemEventType>(value);
 