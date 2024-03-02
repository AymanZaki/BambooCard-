# BambooCard Task

## Overview
This project implements a RESTful API using ASP.NET Core to retrieve details of the best *n* stories from the Hacker News API, where *n* is specified by the caller.

## Hacker News API
The Hacker News API is used to fetch the details of stories. Documentation for the Hacker News API can be found [here](https://github.com/HackerNews/API).

### Endpoints
1. **Best Stories**: IDs for the best stories can be retrieved from `https://hacker-news.firebaseio.com/v0/beststories.json`.
2. **Story Details**: Details for an individual story ID can be retrieved from `https://hacker-news.firebaseio.com/v0/item/{story_id}.json`.

## Implementation Details
- The API returns an array of the best *n* stories as determined by their score, in descending order.
- ASP.NET Core is used to develop the API.

## How to Use
1. Clone the repository.
2. Build and run the project.
3. Make HTTP requests to the API endpoint to retrieve the best *n* stories.

## Usage Example
To retrieve details of the 10 best stories:

GET /api/stories/best?limit=10

## Dependencies
- ASP.NET Core
- Hacker News API


