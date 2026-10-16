# RaceDay Event Management System

## Project Description
RaceDay is a web-based event management system for running, walking, and cycling events.  
This repo contains Part 1 planning deliverables: ERD, API plan, SQL script, CI/CD workflow, and video.

## User Roles
### Organiser
- Create and manage events
- Manage categories
- View enrolments
- Capture results

### Participant
- Register and login
- Browse events
- Enrol in events
- View results

## Deliverables
- docs/RaceDay_ERD.pdf
- docs/RaceDay_API_Endpoint_Plan.md
- docs/RaceDay_Database.sql
- docs/ci-green-screenshot.png

## CI/CD
GitHub Actions workflow validates required files.  
![CI Green Build Screenshot]:

## Video Demonstration
YouTube Link: https://youtu.be/DvczlblqRaI

## Sample Data
When you run the SQL script, it inserts sample records:

- Organisers: 2 (Thabo Mokoena, Zanele Nkosi)
- Participants: 2 (Sipho Dlamini, Lerato Khumalo)
- Events: 3 (Nelson Bay 10K, Port Elizabeth Half Marathon, Bay Cycle Classic)
- Categories: 5 (10K Run, Half Marathon, 50K Cycle, etc.)
- Enrolments: 4 (linking participants to events)
- Results: 1 (Sipho finished Nelson Bay 10K in 42 minutes, position 5)

## Example API Usage
### Register User
POST /api/auth/register  
Body:
```json
{
  "firstName": "Thabo",
  "lastName": "Mokoena",
  "email": "thabo@example.com",
  "password": "12345",
  "role": "Organiser"
}

## Example Event Creation
```markdown
### Create Event
POST /api/events  
Body:
```json
{
  "eventName": "Bay Cycle Classic",
  "description": "Cycling event",
  "eventDate": "2026-12-01",
  "location": "Nelson Mandela Bay",
  "distance": 50,
  "eventType": "Cycle"
}

### Example Enrolment
```markdown
### Enrol Participant
POST /api/enrolments  
Body:
```json
{
  "eventId": 1,
  "categoryId": 2
}


### Example Results
```markdown
### View Results
GET /api/users/me/results  
Response:
```json
[
  { "enrolmentId": 1, "finishTime": "00:42:15", "position": 5 }
]
UPDATED README.md FOR PART 2

# RaceDay API (PROG6212 POE)

## Overview
This project is a RaceDay management API built with ASP.NET Core and Entity Framework Core.  
It allows organisers to manage events, categories, enrolments, and results, while participants can register and view their race outcomes.

## Features
- User registration and login with role assignment (Organiser / Participant)
- Event creation and category management
- Participant enrolment with status tracking
- Result capturing and viewing
- Swagger UI for testing endpoints
- SQL Server integration with EF Core migrations

## Workflow Demonstration
1. Seed Roles (Organiser, Participant)
2. Register users
3. Login to obtain JWT token
4. Create event
5. Create category
6. Enrol participant
7. Capture result
8. View results

## Sample JSON Requests
### Register User
```json
{
  "firstName": "Alice",
  "lastName": "Smith",
  "email": "alice@raceday.com",
  "passwordHash": "Password123!",
  "roleId": 1
}
