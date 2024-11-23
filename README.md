# SQS POC with .NET 8

This project is a Proof of Concept (POC) to demonstrate the use of **Amazon Simple Queue Service (SQS)** with **.NET 8**. The solution contains two projects:

- **MessageProducer**: Responsible for submitting messages to an AWS SQS queue.
- **MessageConsumer**: Consumes messages from the SQS queue and processes them.

## Technologies Used
- **.NET 8**
- **Visual Studio 2022**
- **Amazon SQS**
- **AWS SDK for .NET**

## Prerequisites
- **AWS Account**: Ensure you have access to an AWS account.
- **AWS SQS Queue**: Create a queue in the AWS Management Console.
- **Access Keys**: Generate an access key and secret for your AWS account or IAM user with SQS permissions.
- **Environment Variables**: Configure the following environment variables:
    - `AWS_ACCESS_KEY_ID`: Your AWS access key.
    - `AWS_SECRET_ACCESS_KEY`: Your AWS secret key.
    - `AWS_REGION`: The AWS region where your queue resides.

## Solution Structure
- **MessageProducer**: 
  - Sends messages to the specified SQS queue.
  - Implements `AWS SDK for .NET` to interact with the queue.

- **MessageConsumer**:
  - Continuously polls messages from the SQS queue.
  - Processes and deletes messages after handling them.

## How to Use
- Clone the repository:
   ```bash
   git clone https://github.com/wladsoncedraz/poc-sqs.git
   cd poc-sqs


## Environment Setup

To prepare the local environment for integrating with AWS SQS and configuring the required credentials, follow the steps below:

### 1. Create an AWS Account
If you don¡¯t already have an AWS account:
- Visit [AWS Signup](https://aws.amazon.com/) and complete the registration process.
- Once created, log in to the **AWS Management Console**.

---

### 2. Create an IAM User
- In the AWS Management Console, navigate to **IAM** (Identity and Access Management).
- Go to the **Users** section and click **Add User**.
- Enter a username and select **Programmatic Access** as the access type.
- Proceed to assign permissions.

---

### 3. Create an IAM Group
- In **IAM**, go to **Groups** and click **Create Group**.
- Enter a name for the group (e.g., `SQSAccessGroup`).
- Attach a custom policy for SQS permissions:
   ```json
   {
       "Version": "2012-10-17",
       "Statement": [
           {
               "Effect": "Allow",
               "Action": [
                   "sqs:SendMessage",
                   "sqs:ReceiveMessage",
                   "sqs:DeleteMessage",
                   "sqs:GetQueueAttributes",
                   "sqs:GetQueueUrl"
               ],
               "Resource": "arn:aws:sqs:<region>:<account-id>:<queue-name>"
           }
       ]
   }

### 4. Add the new User to the Group
- Go back to the Users section in IAM.
- Select the user created earlier and click Add to Group.
- Select the group configured in the previous step.

### 5. Generate Access Credentials
- In IAM, select the user and navigate to the Security Credentials tab.
- Click Create Access Key and choose an appropriate usage type (e.g., Local Code for this project).
- Save the following information securely:
    - Access Key: [AWS_ACCESS_KEY_ID]
    - Secret Key: [AWS_SECRET_ACCESS_KEY]
    - Region: [AWS_REGION] (e.g., us-east-1 or sa-east-1 for S?o Paulo)

### 6. Configure Environment Variables
Set up environment variables. On Windows, you can do this via Control Panel > System > Advanced System Settings > Environment Variables:

    AWS_ACCESS_KEY_ID="your-access-key"
    AWS_SECRET_ACCESS_KEY="your-secret-key"
    AWS_REGION="your-region"

### 7. Configure AWS Toolkit in Visual Studio
- Install the AWS Toolkit extension in Visual Studio 2022:
    - Open the Extensions Manager and search for "AWS Toolkit."
    - Install and restart Visual Studio if necessary.
- Connect your account in the AWS Explorer:
    - In the Getting Started menu, select Create a new AWS Builder ID (if needed).
    - Enter the credentials (Access Key and Secret Key) to authenticate.