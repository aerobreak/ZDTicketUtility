import csv
import json
from datetime import datetime
import time
import requests as requests
from requests.structures import CaseInsensitiveDict

ticket_results = []
tickets = []
zendeskPayload = {'tickets': []}
email = 'support@dhecs.com'
password = 'Dhec$Lenovo!'
url = 'https://dhecs.zendesk.com/api/v2/tickets/'
session = requests.Session()
session.auth = (email, password)
ticketFields = {}
shipperInfo = [["School Name", "Ticket Number", "MTM", "Serial", "Date", "Initials"]]
initials = ""
with open('ticket-fields.csv', mode='r') as infile:
    reader = csv.reader(infile)
    for row in reader:
        # add the key value pair to the dictionary ticketFields
        ticketFields[row[0]] = row[1]
def getTicket(ticketNumber):
    url = url = 'https://dhecs.zendesk.com/api/v2/tickets/'
    url = url + str(ticketNumber) + '.json'
    response = requests.get(url, auth=(email, password))
    if response.status_code != 200:
        print('Status:', response.status_code, 'Problem with the request. Exiting.')
        exit()
    else:
        return json.loads(response.text)
def getTicketField(thisTicket, field):
    customFields = thisTicket.get('ticket').get('custom_fields')
    for customField in customFields:
        if ticketFields.get(field) is not None:
            if customField.get('id') == int(ticketFields.get(field)):
                return customField.get('value')
        else:
            return None
def closeTickets(tickets):
    zendeskPayload = {
        'tickets': []
    }
    for thisTicket in tickets:
        print("closeTickets->Closing ticket " + str(thisTicket))

        if (updateLocation(thisTicket) != ""):
            print("closeTickets->Updating location to " + updateLocation(thisTicket))
            jsonData = {'id': thisTicket, 'status': 'solved',
                        'comment': {
                            'body': "Repair complete. QA tests passed. - " + initials},
                        'custom_fields': [{"id": 360015841891, "value": updateLocation(thisTicket)}]
                        }
        else:
            print("closeTickets->No location to update")
            jsonData = {'id': thisTicket, 'status': 'solved',
                        'comment': {'body': "Repair completed. - " + initials}}

        zendeskPayload['tickets'].append(jsonData)
    url = "https://dhecs.zendesk.com/api/v2/tickets/update_many.json"
    headers = CaseInsensitiveDict()
    headers["Content-Type"] = "application/json"
    headers["Authorization"] = "Basic c3VwcG9ydEBkaGVjcy5jb206RGhlYyRMZW5vdm8h"

    response = requests.put(url=url, data=zendeskPayload, headers=headers)
    if response.status_code != 200:
        print(zendeskPayload)
        print('closeTickets>Status:', response.status_code, 'Problem with the request. Exiting.')
        exit()
    return response
def generateShipperLine(ticketNumber):
    thisTicket = getTicket(ticketNumber)
    schoolName = getTicketField(thisTicket, 'School Name')
    if getTicketField(thisTicket, 'School Name') != None:
        schoolName = getTicketField(thisTicket, 'School Name')
    elif getTicketField(thisTicket, 'Company/School') != None:
        schoolName = getTicketField(thisTicket, 'Company/School')
    mtm = getTicketField(thisTicket, 'Computer Model')
    if getTicketField(thisTicket, 'Computer Model') != None:
        mtm = getTicketField(thisTicket, 'Computer Model')
    elif getTicketField(thisTicket, 'Model Name') != None:
        mtm = getTicketField(thisTicket, 'Model Name')
    serial = getTicketField(thisTicket, 'Serial Number')
    newShipperLine = [schoolName, ticketNumber, mtm, serial, datetime.today().strftime('%m/%d/%Y'), initials]
    return newShipperLine
def updateLocation(ticket):
    assignedLocation = getTicketField(ticket, 'Device Location')
    if assignedLocation == "shipped_closed":
        # ("Delivery")
        complete_location = "complete_-_shipping"
    elif assignedLocation == "shipping":
        # ("Shipping")
        complete_location = "closed"
    elif assignedLocation == "will_call":
        # ("Will Call")
        complete_location = "complete_-_will_call"
    else:
        complete_location = ""
    return complete_location


print("Starting pyscript")
with open("exported.txt", "r") as file:
    for line in file:
        if line.startswith("Initials:"):
            initials = line.strip().split(":")[1].strip()
        elif line.startswith("Tickets:"):
            tickets = line.strip().split(":")[1].strip().split(",")
print("Opened exported file")
print("Initials:", initials)
print("Tickets:", tickets)
for ticket in tickets:
    print("ticket: "+ ticket)
    zendeskPayload = {'tickets': []}
    ticketInfo = getTicket(ticket)
    shipperInfo.append(generateShipperLine(ticket))
    complete_location = updateLocation(ticketInfo)
    if complete_location == "":
        print("No location found in ticket " + ticket)
        zd_payload_line = {'id': ticket, 'status': 'solved',
                           'comment': {'body': "Repair complete. QA tests passed. - " + initials}}
    else:
        print("Updating location to " + complete_location)
        zd_payload_line = {'id': ticket, 'status': 'solved',
                           'comment': {'body': "Repair complete. QA tests passed. - " + initials},
                           'custom_fields': [{"id": 360015841891, "value": complete_location}]
                           }
    zendeskPayload['tickets'].append(zd_payload_line)
    url = "https://dhecs.zendesk.com/api/v2/tickets/update_many.json"
    headers = CaseInsensitiveDict()
    headers["Content-Type"] = "application/json"
    headers["Authorization"] = "Basic c3VwcG9ydEBkaGVjcy5jb206RGhlYyRMZW5vdm8h"
    stringify = json.dumps(zendeskPayload)
    print(stringify)
    response = requests.put(url=url, data=stringify, headers=headers)
    print(response.status_code)
    print(response.reason)
    print(response.text)

shipperInfo = shipperInfo[1:]
csv_rows = ["{},{},{},{},{},{}".format(i, j, k, l, m, n) for i, j, k, l, m, n in shipperInfo]
csv_text = "\n".join(csv_rows)

with open('shipper.csv', 'w') as f:
    f.write(csv_text)
print("completed")