Revised Take on Quiz 2 and 3 – Computer Programming 2
For this part of the quiz, I created a Harry Potter–themed shopping cart system. Before coding, I carefully drafted the steps and features I needed—such as the menu, input validation, cart system, and discount logic—so I wouldn’t get lost while coding. I then implemented the program step by step, using commits to track my progress and confirm that each part was working properly.

Features
- Displays a list of products with price and stock
- Allows the user to choose items and enter quantity
- Validates input to prevent errors
- Ensures users cannot buy more than the available stock
- Updates the cart instead of adding duplicates
- Computes the total and applies a 10% discount if it reaches ₱5000
- Shows updated stock after checkout

How It Works
The program begins by displaying the menu, then asks the user to select a product and quantity. It checks if the input is valid and if there is enough stock before adding the item to the cart. The user can continue shopping until they decide to stop. Finally, the program prints a receipt, shows the total, applies any discount, and updates the stock.

AI Usage in This Project
I used AI as a study partner and coding guide. It helped me understand key concepts such as input validation, cart logic, and total computation. AI also suggested structuring the program with classes like Product and CartItem, which made the code cleaner and easier to follow.

However, I did not just copy the AI’s output. I simplified and customized the code to fit my own understanding and added creativity by designing a Harry Potter–inspired Diagon Alley shop theme. This made the project more engaging and unique compared to a standard shopping cart system.

Why AI Was Used
- AI was used mainly to:
- Clarify programming requirements and prevent mistakes
- Guide me in handling validation and avoiding duplicate items
- Help me organize the program into a structured, class-based design
- Ensure my code ran smoothly while still reflecting my own style and theme

Prompts Asked
1. Input Validation & Error Handling
“I want to design a shopping cart system in C# where users can enter product quantities. Show me how to use int.TryParse not just to validate input, but also to give clear error messages, loop back to the menu, and prevent the program from crashing when users type letters or symbols instead of numbers.”

2. Cart Logic & Duplicate Prevention
“In a shopping cart program, how can I structure the logic so that when a user adds the same product twice, the program updates the quantity instead of creating duplicate entries? Demonstrate this using classes like Product and CartItem, and explain how to handle edge cases such as removing items or adjusting stock after checkout.”

3. Discount & Threshold Computation
“I need to implement a discount system where a 10% discount applies only when the total reaches ₱5000. Show me how to structure this logic so it doesn’t trigger early, works consistently across multiple transactions, and can be easily extended later (e.g., adding tiered discounts or promo codes).”

4. Stock Management & Real-World Simulation
“How can I design a stock control system in C# that prevents users from buying more than the available inventory, updates stock after checkout, and displays the remaining items like a real store? Include debugging strategies to catch errors when stock runs out or when multiple users try to buy the same product.”

5. Program Structure & Clean Code
“Demonstrate how to organize a shopping cart program using object-oriented design in C#. Show me how to separate responsibilities into classes (Product, CartItem, Cart, Shop) so the code is reusable, easy to debug, and scalable if I want to add features like receipts, discounts, or themed shop environments (e.g., Harry Potter Diagon Alley).”

Debugging & Testing Strategies
“What debugging strategies can I use to catch errors in cart updates, stock validation, and discount computation? Show me how to test edge cases such as invalid input, zero stock, duplicate items, and totals just below or above the discount threshold.”
