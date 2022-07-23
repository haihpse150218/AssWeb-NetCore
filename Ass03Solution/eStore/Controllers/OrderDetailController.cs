
using BusinessObject;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eStore.Controllers
{
    public class OrderDetailController : Controller
    {
        IOrderDetailServices orderDetailServices = null;

        public OrderDetailController() => orderDetailServices = new OrderDetailServices(Program.ConnectionString);
        // GET: OrderDetailController
        public ActionResult Index(int? orderId)
        {
            if (orderId == null)
            {
                return View(orderDetailServices.GetList());
            }
            return View(orderDetailServices.GetListFromOrder(orderId.Value));
        }

        // GET: OrderDetailController/Details/5
        public ActionResult Details(int orderId, int productId)
        {
            if (orderId == null || productId == null)
            {
                return NotFound();
            }
            var orderDetail = orderDetailServices.GetOrderDetail(orderId, productId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail orderDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderDetailServices.AddOrderDetail(orderDetail);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(orderDetail);
            }
        }

        // GET: OrderDetailController/Edit/5
        public ActionResult Edit(int? orderId, int? productId)
        {
            if (orderId == null || productId == null)
            {
                return NotFound();
            }
            var orderDetail = orderDetailServices.GetOrderDetail(orderId.Value, productId.Value);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? orderId, int? productId, OrderDetail orderDetail)
        {
            try
            {
                if (orderId != orderDetail.OrderId || productId != orderDetail.ProductId)
                {
                    return NotFound();
                }
                orderDetailServices.UpdateOrderDetail(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(orderDetail);
            }
        }

        // GET: OrderDetailController/Delete/5
        public ActionResult Delete(int? orderId, int? productId)
        {
            if (orderId == null || productId == null)
            {
                return NotFound();
            }
            var orderDetail = orderDetailServices.GetOrderDetail(orderId.Value, productId.Value);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int orderId, int productId, OrderDetail orderDetail)
        {
            try
            {
                orderDetailServices.DeleteOrderDetail(orderId, productId);
                return RedirectToAction(nameof(Index), orderId);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
