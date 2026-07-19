# 🚗 Driving License Management System (DVLD)

![Banner](screenshots/banner.png)

A complete desktop application developed in **C# (.NET Framework)** using **Windows Forms** and **SQL Server** for managing driving license services inside a Driving & Vehicle License Department (DVLD).

The application automates the complete licensing workflow, from registering citizens to issuing, renewing, replacing and managing driving licenses.

---

# Features

## 👤 People Management

- Add new people
- Edit existing people
- Delete people
- Search using National Number
- Store personal photo
- Prevent duplicate national numbers

![People](screenshots/people.png)

---

## 👥 User Management

- Add users
- Update users
- Delete users
- Activate / Deactivate accounts
- Password hashing
- User permissions
- Login system
- Last login tracking

![Users](screenshots/users.png)

---

## 📋 Local Driving License Applications

Manage applications for first-time driving licenses.

Features include:

- Create applications
- Validate applicant age
- Prevent duplicate active applications
- Link applications to people
- Application status management

![Applications](screenshots/applications.png)

---

## 🚦 Driving Tests

The application supports the complete testing workflow.

### Vision Test

- Schedule appointment
- Record result
- Retry failed test

![Vision Test](screenshots/vision-test.png)

---

### Written Test

- Schedule written exam
- Record score
- Pass / Fail

![Written Test](screenshots/written-test.png)

---

### Street Test

- Schedule practical driving test
- Record result
- Retry failed attempts

![Street Test](screenshots/street-test.png)

---

## 🪪 License Issuing

Issue a driving license after passing all required tests.

The system automatically validates:

- Minimum age
- Existing licenses
- Test completion
- Application status

![Issue License](screenshots/issue-license.png)

---

## 🆔 Driving License Card

View detailed license information.

Displayed information includes:

- License Number
- Driver Information
- License Class
- Issue Date
- Expiration Date
- Notes
- Active Status

![License Card](screenshots/license-info.png)

---

## 🌍 International License

Issue international licenses for eligible drivers.

Rules implemented:

- Only Class 3 licenses
- License must be active
- License must not be detained
- Prevent duplicate active international licenses

![International License](screenshots/international-license.png)

---

## 🔄 License Renewal

Renew expired licenses.

Features:

- Automatic fee calculation
- Expiration validation
- Vision test validation
- New license generation

![Renew License](screenshots/renew-license.png)

---

## 📄 Replacement Licenses

Support for:

- Lost licenses
- Damaged licenses

The system keeps the history of all replacements.

![Replacement](screenshots/replacement-license.png)

---

## 🚓 Detained Licenses

Detain licenses.

Features:

- Register detention
- Store detention reason
- Register fine
- Track detention history

![Detained](screenshots/detained-license.png)

---

## ✅ Release Detained License

Release detained licenses after paying fines.

![Release](screenshots/release-license.png)

---

## 🚘 Driver Management

Once a license is issued, the person automatically becomes a registered driver.

Features:

- Driver history
- License history
- International license history

![Drivers](screenshots/drivers.png)

---

## ⚙ Administration

### Application Types

Modify application fees.

![Application Types](screenshots/application-types.png)

---

### Test Types

Modify testing fees.

![Test Types](screenshots/test-types.png)

---

# Business Rules

The system implements more than 40 business rules, including:

- Minimum age validation
- Duplicate application prevention
- Duplicate license prevention
- Sequential test workflow
- License expiration validation
- License detention validation
- Replacement validation
- International license eligibility
- Automatic driver creation
- Complete application history
- User activity logging
- Password hashing

---

# Technologies Used

- C#
- Windows Forms
- .NET Framework
- SQL Server
- ADO.NET
- Layered Architecture (3-Tier)
- Object-Oriented Programming

---

# Architecture

```
Presentation Layer
        │
        ▼
Business Layer
        │
        ▼
Data Access Layer
        │
        ▼
SQL Server Database
```

---

# Database

The application uses a relational SQL Server database designed to support the complete licensing workflow.

![Database](screenshots/database.png)

---

# Project Statistics

- 20+ Windows Forms
- 100+ Classes
- Complete CRUD Operations
- Multi-layer Architecture
- Authentication System
- Driving Test Workflow
- License Issuing Workflow
- Driver Management
- International Licenses
- Renewal System
- Detained Licenses
- Event Logging
- Password Hashing

---

# Future Improvements

- Barcode / QR Code licenses
- Email notifications
- Online appointment booking
- Digital license generation
- REST API
- Role-based authorization
- Reporting Dashboard

---

# Author

**Mohamed Ben Tekaya**

Computer Science Student
