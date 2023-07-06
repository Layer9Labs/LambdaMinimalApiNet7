# LambdaMinimalApiNet7

From your clone, setup an [Environment](https://docs.github.com/en/actions/deployment/targeting-different-environments/using-environments-for-deployment) called `Test`

With that set up the following:

### Environment secrets
* `AWS_ACCESS_KEY_ID` - your AWS Access Key
* `AWS_SECRET_ACCESS_KEY` - your AWS Secret Access Key for the above ID

### Environment variables
* `REGION` - the AWS region you wish to deploy to
* `BUCKET` - the S3 bucket the above secrets have access to as part of the serverless deployment
* `STACK` - the name of the CloudFormation Stack that you want to use

### Deployment
Once cloned and configured as above, the `workflow-dispatch` can be triggered on the `Build & Deploy Lambda` [workflow](.github/workflows/main.yml) can be triggered.
### Testing
One the above workflow is complete, and the Lambda is deployed, you can review the output of the workflow to find the API Gateway endpoint at the end of the `Deploy Stack/Lambda` step.
Look for:

```
Output Name                    Value                                             
------------------------------ --------------------------------------------------
ApiURL                         https://XXX.execute-api.<REGION>>.amazonaws.com/Prod/
```
You can paste this into a browser and should get as a response:
```
{"Message": "Welcome to running ASP.NET Core Minimal API on AWS Lambda"} 
```
What we see is:
```
{"message": "Endpoint request timed out"}
```
