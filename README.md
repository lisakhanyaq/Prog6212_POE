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
