using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MessageService" in both code and config file together.
    public class MessageService : IMessageService
    {
        public bool AddNewMessage(string text)
        {
            using (MessageEntities MessageEntity = new MessageEntities())
            {
                try
                {
                    Messages newMessage = new Messages(text);
                    MessageEntity.Messages.Add(newMessage);
                    MessageEntity.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<Messages> GetAllMessages()
        {
            List<Messages> messageList = new List<Messages>();

            using (MessageEntities MessageEntity = new MessageEntities())
            {
                var allMessages = from m in MessageEntity.Messages
                                  orderby m.TimeStamp descending
                                  select m;

                messageList = allMessages.ToList();
            }

            return messageList;
        }
    }
}
