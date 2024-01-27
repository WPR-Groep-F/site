import React, {useState} from 'react';
import {Form, Button, Container, Row, Col, Card} from 'react-bootstrap';
import {useMutation, useQueryClient} from 'react-query';
import axiosInstance from "../Services/axiosInstance.js";
import {apiPath} from "../util/api.jsx";

function InviteForm() {
    const [BedrijfNaam, setBedrijfNaam] = useState('');
    const [BedrijfEmail, setBedrijfEmail] = useState('');
    const [isUsed, setIsUsed] = useState(false);
    const [isExpired, setIsExpired] = useState(false);

    const queryClient = useQueryClient();

    const mutation = useMutation(newInvite => axiosInstance.post(`${apiPath}/api/BeheerderPortaal/InviteBedrijf`, newInvite), {
        onSuccess: () => {
            setBedrijfNaam('');
            setBedrijfEmail('');
            setIsUsed(false);
            setIsExpired(false);


            queryClient.invalidateQueries('tableData');
        },

    });

    const handleSubmit = (event) => {
        event.preventDefault();

        mutation.mutate({
            "email": BedrijfEmail,
            "naam": BedrijfNaam

        });
    };

    return (

        <Card className={"Shadow"}>
            <Card.Body>
                <Form onSubmit={handleSubmit}>
                    <Row>
                        <Col>
                            <Form.Group>
                                <Form.Label>Bedrijf naam</Form.Label>
                                <Form.Control
                                    type={"text"}
                                    placeholder={"Enter bedrijf naam"}
                                    value={BedrijfNaam}
                                    onChange={e => setBedrijfNaam(e.target.value)}
                                />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group>
                                <Form.Label>Bedrijf email</Form.Label>
                                <Form.Control
                                    type={"email"}
                                    placeholder={"Enter bedrijf email"}
                                    value={BedrijfEmail}
                                    onChange={e => setBedrijfEmail(e.target.value)}
                                />
                            </Form.Group>
                        </Col>
                        <Col className={"d-flex align-items-end justify-content-center"}>
                            <Button variant="primary" type="submit" onClick={handleSubmit}>
                                Submit
                            </Button>
                        </Col>
                    </Row>
                </Form>
            </Card.Body>
        </Card>
       
    );
}

export default InviteForm;