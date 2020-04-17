CREATE TABLE Users (
	UserId INT NOT NULL UNIQUE,
	PhoneNumber VARCHAR(10) NOT NULL,
	Email VARCHAR(30) NOT NULL,
	Password VARCHAR(15) NOT NULL,
	Address VARCHAR(150) NOT NULL,
	Budget VARCHAR(150) NOT NULL,
	LoanApplication VARCHAR(150) NOT NULL,
	Analytics VARCHAR(150) NOT NULL,
	Membership BIT NOT NULL
);

CREATE TABLE Budget (
	BudgetId INT NOT NULL UNIQUE,
	EstMonthlyCost MONEY NOT NULL,
	ActualMonthlyCost MONEY NOT NULL,
	Bill_Id INT NOT NULL,
	SubscriptionID INT NOT NULL,
	LoanId INT NOT NULL,

);

CREATE TABLE Bills (
	Bill_Id INT NOT NULL UNIQUE,
	PurchaseName VARCHAR(50) NOT NULL,
	Quantity INT NOT NULL,
	Cost MONEY NOT NULL, 
	BillDate DATE NOT NULL,
	BillLocation VARCHAR(150) NOT NULL,
);

CREATE TABLE Subscriptions (
	SubscriptionID INT NOT NULL UNIQUE,
	CompanyName VARCHAR(40) NOT NULL,
	SubscriptionName VARCHAR(48) NOT NULL,
	SubscriptionMonthCost MONEY NOT NULL,
	SubscriptionDate Datetime2 NOT NULL,
	SubscriptionDueDate Datetime2 NOT NULL,
	Notification BIT NOT NULL, 
);

CREATE TABLE Loan (
	LoanId INT NOT NULL UNIQUE,
	MonthlyRate DECIMAL NOT NULL,
	InterestRate DECIMAL NOT NULL,
	RetainingCost MONEY NOT NULL,
	AccumulatedCost MONEY NOT NULL,

);

CREATE TABLE LoanApplication (
	SSN VARCHAR(9) NOT NULL UNIQUE,
	CreditScore DECIMAL NOT NULL,
	EstIncome MONEY NOT NULL,
	ApprovalDenialComformation BIT,
	LoanAmount MONEY NOT NULL,
	UserId VARCHAR(10) NOT NULL,
);