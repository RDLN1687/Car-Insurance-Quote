using CarInsurance.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        public long DateOfBirth { get; private set; }

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create([Bind()] Insuree insuree)
        {
            {
                DateTime currentDate = DateTime.Now;
                DateTime birthdate = new DateTime(DateOfBirth);

                int Age = currentDate.Year - birthdate.Year;
                if (currentDate.Month < birthdate.Month || (currentDate.Month == birthdate.Month && currentDate.Day < birthdate.Day))
                {
                    Age--;
                }

                if (ModelState.IsValid)
                {
                    decimal quote = 50;




                    if (insuree.Age <= 18)
                    {
                        quote += 100;
                    }
                    else if (insuree.Age >= 19 && insuree.Age <= 25)
                    {
                        quote += 50;
                    }
                    else
                    {
                        quote += 25;
                    }

                    if (insuree.CarYear < 2000)
                    {
                        quote += 25;
                    }

                    else if (insuree.CarYear > 2015)
                    {
                        quote += 25;
                    }

                    if (insuree.CarMake == "Porche")
                    {
                        quote += 25;

                        if (insuree.CarModel == "911 Carrera")
                        {
                            quote += 25;
                        }
                    }

                    quote += 10 * insuree.SpeedingTickets;

                    if (insuree.DUI)
                    {
                        quote *= 1.25m;
                    }

                    if (insuree.FullCoverage)
                    {
                        quote *= 1.5m;
                    }

                    insuree.Quote = quote;
                    db.Insurees.Add(insuree);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }

            //    get: insuree/details/5
            //    public actionresult details(int? id)
            //    {
            //        if (id == null)
            //        {
            //            return new httpstatuscoderesult(httpstatuscode.badrequest);
            //        }
            //        insuree insuree = db.insurees.find(id);
            //        if (insuree == null)
            //        {
            //            return httpnotfound();
            //        }
            //        return view(insuree);
            //    }

            //    get: insuree/create
            //    public actionresult create()
            //    {
            //        return view();
            //    }

            //    post: insuree/create
            //    to protect from overposting attacks, enable the specific properties you want to bind to, for 
            //     more details see https://go.microsoft.com/fwlink/?linkid=317598.
            //    [httppost]
            //    [validateantiforgerytoken]
            //    public actionresult create([bind(include = "id,firstname,lastname,emailaddress,dateofbirth,caryear,carmodel,carmake,dui,speedingtickets,coveragetype,quote")] insuree insuree)
            //    {
            //        if (modelstate.isvalid)
            //        {
            //            db.insurees.add(insuree);
            //            db.savechanges();
            //            return redirecttoaction("index");
            //        }

            //        return view(insuree);
            //    }

            //    get: insuree/edit/5
            //    public actionresult edit(int? id)
            //    {
            //        if (id == null)
            //        {
            //            return new httpstatuscoderesult(httpstatuscode.badrequest);
            //        }
            //        insuree insuree = db.insurees.find(id);
            //        if (insuree == null)
            //        {
            //            return httpnotfound();
            //        }
            //        return view(insuree);
            //    }

            //    post: insuree/edit/5
            //     to protect from overposting attacks, enable the specific properties you want to bind to, for 
            //     more details see https://go.microsoft.com/fwlink/?linkid=317598.
            //    [httppost]
            //    [validateantiforgerytoken]
            //    public actionresult edit([bind(include = "id,firstname,lastname,emailaddress,dateofbirth,caryear,carmodel,carmake,dui,speedingtickets,coveragetype,quote")] insuree insuree)
            //    {
            //        if (modelstate.isvalid)
            //        {
            //            db.entry(insuree).state = entitystate.modified;
            //            db.savechanges();
            //            return redirecttoaction("index");
            //        }
            //        return view(insuree);
            //    }

            //    get: insuree/delete/5
            //    public actionresult delete(int? id)
            //    {
            //        if (id == null)
            //        {
            //            return new httpstatuscoderesult(httpstatuscode.badrequest);
            //        }
            //        insuree insuree = db.insurees.find(id);
            //        if (insuree == null)
            //        {
            //            return httpnotfound();
            //        }
            //        return view(insuree);
            //    }

            //    // post: insuree/delete/5
            //    [httppost, actionname("delete")]
            //    [validateantiforgerytoken]
            //    public actionresult deleteconfirmed(int id)
            //    {
            //        insuree insuree = db.insurees.find(id);
            //        db.insurees.remove(insuree);
            //        db.savechanges();
            //        return redirecttoaction("index");
            //    }

            //    protected override void dispose(bool disposing)
            //    {
            //        if (disposing)
            //        {
            //            db.dispose();
            //        }
            //        base.dispose(disposing);
            //    }


        }

    }
}