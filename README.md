# Enhanced Shopping Cart System
- This program is an enhanced version of a Shopping Cart System developed in C#. It allows users to select products, manage their cart, process payments, and generate receipts. This project was created as part of programming activity to apply basic concepts in C#.

Features
- Cart Management
- View cart
- Remove item
- Update item quantity
- Clear cart
- Checkout

Products
- Shows list of products  
- Each product has category and stock

Payment
- Checks if input is number  
- Makes sure payment is enough  
- Calculates change

Receipt
- Shows receipt number  
- Shows date and time  
- Displays items bought  
- Shows total, discount, and final price  
- Shows payment and change

 Stock System
- Stock is reduced after buying  
- Shows warning if stock is low (5 or below)

Order History
- Saves previous orders  
- Displays past receipts 

Validation
- Prevents wrong inputs (letters instead of numbers)  
- Accepts only Y/N when needed  

Concepts Used
- Classes (Product, CartItem)  
- Arrays (for product list)  
- Lists (for cart and history)  
- Loops (for, while)  
- If-else conditions  
- Input validation 

How It Works
1. User selects a product  
2. User enters quantity  
3. System checks stock availability  
4. Item is added to cart  
5. User manages cart (view/update/remove)  
6. User proceeds to checkout  
7. Payment is validated  
8. Receipt is generated  

Challenges Encountered
- Handling invalid input without crashing  
- Managing cart items without duplication  
- Updating stock correctly after purchase  
- Implementing payment validation  

AI Usage
I used AI as a support tool to:
- Debug errors and improve input validation  
- Understand specific programming concepts  
- Get suggestions for structuring my code  

I used targeted prompts to solve specific problems, then applied and modified the solutions in my own code.

Example prompts:
- "How to validate user input in C# using TryParse?"
- "How to manage a shopping cart using List in C#?"
- "How to compute total, discount, and payment validation in C# console app?"

All AI-generated suggestions were tested, adjusted, and fully understood before being used in the final program.

