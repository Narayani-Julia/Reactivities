type Activity = {
    id: int
    title: string
    date: string
    description: string
    category: string
    isCancelled: boolean
    city: string
    venue: string
    latitude: number
    longitude: number
}

type Student = {
    id: int
    firstName: string
    lastName: string
}

type Course = {
    id: int
    courseId: string
    department: string
    registrationCap: number
    location: string
    startTime: DateTime
    isOffline: boolean
}

type Teacher = {
    id: int    
    firstName: string
    lastName: string
    department: string
    officeNo: string
    emailAddress: string
}