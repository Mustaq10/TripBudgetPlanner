**1. Project Goals** 
Trip Budget Planner is a .NET MAUI cross-platform mobile app designed for travellers to plan 
budgets, track expenses, and maintain financial control during trips. 
 
The app solves problems faced by travellers such as: 
• overspending due to no real tracking 
• losing paper receipts 
• difficulty in understanding spending distribution 
• no organized view of trip expenses 
 
The app allows users to: 
 
●  Create trips with budget 
●  Add categorized expenses 
●  View remaining budget 
●  Track expenses visually 
●  Stay within budget 
●  Use the app fully offline (SQLite local DB) 
 
The app follows the MVVM architecture, ensuring clean separation of UI, logic, and data. 


**2. Main Functionalities** 
i. Create and Manage Multiple Trips 
● Add multiple trips with destination, dates, and budget 
● View trips in a styled list 
● Select any trip to view details 
ii. Add and Categorize Expenses 
● Add expenses to each trip 
● Choose from predefined categories (Food, Travel, Hotel, Shopping, Fuel, etc.) 
● Expenses are stored locally and displayed immediately 
iii. Real-Time Dashboard 
● Total trips 
● Total expenses 
● Total budget 
● Category-wise expense visualization (Progress Bars) 
iv. Budget Tracking Alerts 
● If spending reaches the budget limit, trip details highlight the updates 
● Users can visually see remaining budget 
v. SQLite Local Database 
● All trips and expenses stored in device using SQLite 
● App fully works offline 
● Fast, lightweight local data store 

 
**3. App Architecture Diagram (Navigation Flow)** 
 
 
Home Page 
     | 
     V 
Dashboard Page 
     | 
     V 
Trip List Page 
   /       \ 
Add Trip   Trip Details 
              | 
              V 
         Add Expense 
**Navigation Summary** 
● Home Page: Shows greeting, stats, featured destinations, recent trips 
● Trip List Page: Shows all trips with image banners & progress bars 
● Add Trip Page: Create a new trip with name, budget, and dates 
● Trip Details Page: Shows budget, expenses, and add-expense button 
● Add Expense Page: Add categorized expenses 
● Dashboard Page: Shows total budget, expenses, category breakdown (progress bars), 
top trips 
The app uses Shell Navigation, providing smooth transitions. 
 

**4.Technologies used**
| Component                | Technology         | Description                |
| ------------------------ | ------------------ | -------------------------- |
| **Frontend (UI)**        | .NET MAUI (XAML)   | Cross-platform UI design   |
| **Language**             | C#                 | Business logic and backend |
| **Architecture Pattern** | MVVM               | Separation of UI and logic |
| **Database**             | SQLite             | Local offline data storage |
| **IDE**                  | Visual Studio 2022 | App development            |
| **Version Control**      | GitHub             | Team collaboration         |

 
**5.User Documentation (Simple Guide)** 
How to Use the App 
1. Open the app → Home page loads 
2. Tap Add Trip to create a new trip 
§ Trip Name 
§ Budget 
§ Start & End Dates 
3. Open any trip from the Trip List 
4. Tap Add Expense 
§ Select Category 
§ Enter Amount & Description 
5. View trip expenses and remaining budget on Trip Details 
6. Open Dashboard to view: 
§ Total trips 
§ Total budget 
§ Total expenses 
§ Category-wise spending 
The app stores all data locally on the device. 
 
**6. Conclusion** 
The Trip Budget Planner demonstrates: 
● Real-world mobile app using .NET MAUI 
● Modern UI using XAML 
● Offline-first architecture using SQLite 
● MVVM-based clean structure 
● Simple, fast budgeting tool for travellers 
This project reflects strong teamwork and practical implementation of mobile development 
concepts learned during the course. 
 
 
 
 
 
