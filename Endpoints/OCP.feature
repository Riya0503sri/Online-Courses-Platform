Feature: OCP

Scenario: Get all Courses
	Given I am a client
	When I make GET Request to '/courses'
	Then response code must be 200
	And response data must look like '[{"id":1,"name":"TestName","totalDuration":15}]'

Scenario: Get all available schedules for a course
	Given I am a client
	When I make GET Request to '<endpoint>'
	Then response code must be <statusCode>
	And response data must look like '<response>'
	Examples: 
	| endpoint              | statuscode | response                                                                                        |
	| courses/1/schedules   | 200        | [{"id":1,"courseId":1,"teacherId":2,"day":"Monday","startTime":"12:00 PM","endTime":"1:00 PM"}] |
	| courses/100/schedules | 404        | Not found                                                                                       |

Scenario: Get all courses taught by a particular teacher
	Given I am a client
	When I make GET Request to '/teachers/{id}/courses'
	Then response code must be 200
	And response data must look like '[{"id":1,"name":"TestTeacher","courses":[{"id":1,"name":"computerscience","totalDuration":15}]}]'


Scenario: Register a new student with a course and its schedule
	Given I am a client
	When I make a POST Request to '/students/{studentId}/courses' with following data '[{"courseId":1,"scheduleId":2}]'
	Then Response status code must be '201'


Scenario: Enroll the student for a new course and its schedule
	Given I am a user
	When I make a POST Request to '/enrollments' with following data '[{"studentId":1,"courseId":2,"scheduleId":1}]'
	Then Response status code must be '201'