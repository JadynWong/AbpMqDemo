using System;

namespace MqEvent
{
    public class TestMessagesEventData
    {
        public string Text { get; set; }

        protected TestMessagesEventData()
        {

        }

        public TestMessagesEventData(string text)
        {
            Text = text;
        }
    }
}
