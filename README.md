Last thing I did not have time with, is to use the
   Open-closed principle, for the PriorityRaise on the "Default"
   as well as "Special" cases, the latter being with t containing
   string such as "Crash, Important, Failure".
   This is to avoid changing the code, as well as to 
   avoid repeatition. By utilizing the Open-closed
   principle we don't have to be worried about any modification
   being made on the method, as well as being able to continously add
   different and more methods to raise the priority, with different
   arguments.

   I did create an interface "IPriorityRaise" which the class:"DefaultPriority, SpecialPriority"
   is inheriting from, and to further extend functionality. In this case
   to act as the "Default" and "Special" cases in the TicketService class.
   However, to be able to add more and different PriorityRaises, the
   program needs to know which one to use, which the "PriorityRaiseHandler"
   is there for, to act as a "chooser" to pick what kind of PriorityRaise
   function to use, and when. 
