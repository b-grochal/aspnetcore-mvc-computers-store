using ComputersStore.Core.Data;
using ComputersStore.Core.Dictionaries;
using ComputersStore.Data;
using ComputersStore.Database.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputersStore.Database.DbInitializer
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext applicationDbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            //EnsureDatabaseCreated(applicationDbContext);
            SeedUserRoles(roleManager);
            SeedUsers(userManager);
            SeedProductCategories(applicationDbContext);
            SeedOrderStatuses(applicationDbContext);
            SeedPaymentTypes(applicationDbContext);
            SeedProducts(applicationDbContext);
            SeedOrders(applicationDbContext);
            SeedOrderItems(applicationDbContext);
            //SaveChanges(applicationDbContext);
        }

        private static void EnsureDatabaseCreated(ApplicationDbContext applicationDbContext)
        {
            applicationDbContext.Database.EnsureCreated();
        }

        private static void SaveChanges(ApplicationDbContext applicationDbContext)
        {
            applicationDbContext.SaveChanges();
        }


        private static void SeedOrderItems(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.OrderItems.Any())
            {
                var orderItems = new List<OrderItem>
                {
                        new OrderItem{OrderId=1,ProductId=1,Quantity=1},
                        new OrderItem{OrderId=1,ProductId=3,Quantity=1},
                        new OrderItem{OrderId=1,ProductId=5,Quantity=1},
                        new OrderItem{OrderId=1,ProductId=7,Quantity=1},
                        new OrderItem{OrderId=1,ProductId=9,Quantity=1},
                        new OrderItem{OrderId=1,ProductId=11,Quantity=2},
                };
                orderItems.ForEach(x => applicationDbContext.OrderItems.Add(x));
                applicationDbContext.SaveChanges();
            }
        }

        private static void SeedOrders(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Orders.Any())
            {
                var orders = new List<Order>
                {
                      new Order
                      {
                          ApplicationUserId = applicationDbContext.Users.First(x => x.Email.Equals("dwight@shrute.com")).Id,
                          OrderStatusId = OrderStatusDictionary.New,
                          PaymentTypeId = PaymentTypeDictionary.Cash,
                          OrderDate = DateTime.Now,
                          ShipAddress ="2890  Golf Course Drive",
                          ShipCity = "Houck",
                          ShipCountry = "USA",
                          ShipPostalCode = "86506"
                      }
                };
                orders.ForEach(x => applicationDbContext.Orders.Add(x));
                applicationDbContext.SaveChanges();
            }
        }

        private static void SeedProducts(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Products.Any())
            {
                var products = new List<Product>
                    {
                        new CentralProcessingUnit
                        {
                            Name = "AMD Ryzen 5 2600",
                            Description = "3.4GHz, 16 MB, BOX (YD2600BBAFBOX)",
                            Price = 565,
                            ProductCategoryId = ProductCategoryDictionary.CPU,
                            NumberOfCores = 6,
                            NumberOfThreads = 12,
                            ClockSpeed = "3.4 GHz",
                            TDP = "65 W",
                            Socket = "AM4",
                            Architecture = "Zen+",
                            ManufacturingProcess = "12 nm"
                        },
                        new CentralProcessingUnit
                        {
                            Name = "Intel Core i5-9400F",
                            Description = "2.9GHz, 9 MB, BOX (BX80684I59400F)",
                            Price = 565,
                            ProductCategoryId = ProductCategoryDictionary.CPU,
                            NumberOfCores = 6,
                            NumberOfThreads = 6,
                            ClockSpeed = "2.9 GHz",
                            TDP = "65 W",
                            Socket = "Socket 1151",
                            Architecture = "Coffe Lake",
                            ManufacturingProcess = "14 nm"
                        },
                        new Motherboard
                        {
                            Name = "Gigabyte B450 AORUS ELITE",
                            Description = "Socket AM4 AMD B450 DDR4 ATX",
                            Price = 385,
                            ProductCategoryId = ProductCategoryDictionary.Motherboard,
                            FormFactor = "ATX",
                            CpuSocket = "Socket AM4",
                            Chipset = "AMD B450",
                            MemoryType = "DDR4",
                            MemoryChannel = "Dual-Channel",
                            SataSupport = "SATA III"
                        },
                        new Motherboard
                        {
                            Name = "MSI B450-A PRO MAX",
                            Description = "Socket AM4 AMD B450 DDR4 ATX",
                            Price = 419,
                            ProductCategoryId = ProductCategoryDictionary.Motherboard,
                            FormFactor = "ATX",
                            CpuSocket = "Socket AM4",
                            Chipset = "AMD B450",
                            MemoryType = "DDR4",
                            MemoryChannel = "Dual-Channel",
                            SataSupport = "SATA III"
                        },
                        new RandomAccessMemory
                        {
                            Name = "Corsair Vengeance RGB PRO",
                            Description = "DDR4, 16 GB,3200MHz, CL16 (CMW16GX4M2C3200C16)",
                            Price = 429,
                            ProductCategoryId = ProductCategoryDictionary.RAM,
                            Size = "16 GB",
                            Type = "DDR4",
                            Speed = "3200 MHz",
                            CasLatency = "CL16"
                        },
                        new RandomAccessMemory
                        {
                            Name = "HyperX Fury",
                            Description = "DDR4, 16 GB,2666MHz, CL16 (HX426C16FB3K2/16)",
                            Price = 298.40m,
                            ProductCategoryId = ProductCategoryDictionary.RAM,
                            Size = "16 GB",
                            Type = "DDR4",
                            Speed = "2666 MHz",
                            CasLatency = "CL16"
                        },
                        new GraphicsProcessingUnit
                        {
                            Name = "MSI GeForce GTX 1660 Ventus XS OC",
                            Description = "Descritprion for GPU",
                            Price = 1019,
                            ProductCategoryId = ProductCategoryDictionary.GPU,
                            MemorySize = "6 GB",
                            MemoryType = "GDDR5",
                            MemorySpeed = "8000 Mhz",
                            MemoryBus = "192 bit",
                            Interface = "PCI Express 3.0 x16"

                        },
                        new GraphicsProcessingUnit
                        {
                            Name = "Gigabyte GeForce RTX 2060 OC",
                            Description = "Descritprion for GPU",
                            Price = 1399,
                            ProductCategoryId = ProductCategoryDictionary.GPU,
                            MemorySize = "6 GB",
                            MemoryType = "GDDR6",
                            MemorySpeed = "14000 MHz",
                            MemoryBus = "192 bit",
                            Interface = "PCI Express 3.0 x16"

                        },
                        new PowerSupplyUnit
                        {
                            Name = "Thermaltake Smart SE2 500",
                            Description = "500W ATX",
                            Price = 183.85m,
                            ProductCategoryId = ProductCategoryDictionary.PSU,
                            Size = "ATX",
                            Wattage = "500 W",

                        },
                        new PowerSupplyUnit
                        {
                            Name = "SilentiumPC Vero L2 600W",
                            Description = "600W ATX",
                            Price = 139,
                            ProductCategoryId = ProductCategoryDictionary.PSU,
                            Size = "ATX",
                            Wattage = "600 W"
                        },
                        new HardDiskDrive
                        {
                            Name = "Toshiba P300",
                            Description = "2 TB 3.5\" SATA 3 (HDWD120UZSVA)",
                            Price = 257.99m,
                            ProductCategoryId = ProductCategoryDictionary.HDD,
                            Capacity = "2 TB",
                            RotationSpeed = "7200",
                            CacheSize = "64 MB",
                            Interface = "SATA 3"
                        },
                        new HardDiskDrive
                        {
                            Name = "Western Digital Black 1",
                            Description = "1 TB 3.5\" SATA 3 (WD1003FZEX)",
                            Price = 343.23m,
                            ProductCategoryId = ProductCategoryDictionary.HDD,
                            Capacity = "1 TB",
                            RotationSpeed = "7200",
                            CacheSize = "64 MB",
                            Interface = "SATA 3"
                        },
                        new SolidStateDrive
                        {
                            Name = "Kingston UV500",
                            Description = "240 GB SATA 3 (SUV500/240G)",
                            Price = 230.40m,
                            ProductCategoryId = ProductCategoryDictionary.SSD,
                            Capacity = "240 GB",
                            Interface = "SATA 3"
                        },
                        new SolidStateDrive
                        {
                            Name = "ADATA SU800",
                            Description = "512 GB SATA 3 (ASU800SS-512GT-C)",
                            Price = 386.99m,
                            ProductCategoryId = ProductCategoryDictionary.SSD,
                            Capacity = "512 GB",
                            Interface = "SATA 3"
                        },
                    };
                products.ForEach(x => applicationDbContext.Products.Add(x));
                applicationDbContext.SaveChanges();
            }
        }

        private static void SeedUserRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString())).Wait();
                roleManager.CreateAsync(new IdentityRole(UserRoles.User.ToString())).Wait();
            }
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var applicationUsers = new List<ApplicationUser>
                {
                    new ApplicationUser{Email="michael@scott.com",UserName="michael@scott.com",PhoneNumber="123-123-123",FirstName="Michael",LastName="Scott",EmailConfirmed=true,PhoneNumberConfirmed=true},
                    new ApplicationUser{Email="dwight@shrute.com",UserName="dwight@shrute.com",PhoneNumber="123-123-123",FirstName="Dwight",LastName="Schrute",EmailConfirmed=true,PhoneNumberConfirmed=true}
                };

                foreach (var user in applicationUsers)
                {
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "P@ssw0rd");
                    userManager.CreateAsync(user).Wait();
                }
                userManager.AddToRoleAsync(applicationUsers.Find(x => x.Email.Equals("michael@scott.com")), UserRoles.Admin.ToString()).Wait();
                userManager.AddToRoleAsync(applicationUsers.Find(x => x.Email.Equals("dwight@shrute.com")), UserRoles.User.ToString()).Wait();
            }
        }

        private static void SeedOrderStatuses(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.OrderStatuses.Any())
            {
                var orderItems = new List<OrderStatus>
                {
                        new OrderStatus{Name="New"},
                        new OrderStatus{Name="In progress"},
                        new OrderStatus{Name="Ready"},
                        new OrderStatus{Name="Realized"}
                };
                orderItems.ForEach(x => applicationDbContext.OrderStatuses.Add(x));
                applicationDbContext.SaveChanges();
            }
        }

        private static void SeedProductCategories(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.ProductCategories.Any())
            {
                var orderItems = new List<ProductCategory>
                {
                        new ProductCategory{Name="CPU"},
                        new ProductCategory{Name="Motherboard"},
                        new ProductCategory{Name="RAM"},
                        new ProductCategory{Name="GPU"},
                        new ProductCategory{Name="PSU"},
                        new ProductCategory{Name="HDD"},
                        new ProductCategory{Name="SSD"}
                };
                orderItems.ForEach(x => applicationDbContext.ProductCategories.Add(x));
                applicationDbContext.SaveChanges();
            }
        }

        private static void SeedPaymentTypes(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.PaymentTypes.Any())
            {
                var orderItems = new List<PaymentType>
                {
                        new PaymentType{Name="Cash"},
                        new PaymentType{Name="Bank transfer"},
                };
                orderItems.ForEach(x => applicationDbContext.PaymentTypes.Add(x));
                applicationDbContext.SaveChanges();
            }
        }
    }
}
