﻿using System;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Services.Order.Infrastructure;
using FreeCourse.Shared.Messages;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace FreeCourse.Services.Order.Application.Consumer
{
	public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
	{
        private readonly OrderDbContext _orderDbContext;

        public CourseNameChangedEventConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var orderItems = await _orderDbContext.OrderItems
                .Where(x => x.ProductId == context.Message.CourseId)
                .ToListAsync();

            orderItems.ForEach(x =>
            {
                x.UpdateOrderItem(context.Message.UpdatedName, x.PictureUrl, x.Price);
            });

            await _orderDbContext.SaveChangesAsync();

        }
    }
}

