import { Form, Button, Container, Row, Col, Card } from "react-bootstrap";
import { useState } from "react";

function CreateNewUitnodiging(props) {
  const [Routebeschrijving, setRoutebeschrijving] = useState("");
  const [Datum, setDatum] = useState("");
  const [Tijd, setTijd] = useState("");
  const [Adres, setAdres] = useState("");


  
  return (
    <>
      <Card className={"Shadow"}>
        <Card.Body>
          <Form onSubmit={handleSubmit}>
            <Row>
              <Col>
                <Form.Group>
                  <Form.Label>Adres</Form.Label>
                  <Form.Control
                    type={"text"}
                    placeholder={"Enter bedrijf naam"}
                    value={Adres}
                    onChange={(e) => setAdres(e.target.value)}
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group>
                  <Form.Label>Datum</Form.Label>
                  <Form.Control
                    type={"email"}
                    placeholder={"Enter bedrijf email"}
                    value={Datum}
                    onChange={(e) => setDatum(e.target.value)}
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group>
                  <Form.Label>Tijd</Form.Label>
                  <Form.Control
                    type={"email"}
                    placeholder={"Enter bedrijf email"}
                    value={Tijd}
                    onChange={(e) => setTijd(e.target.value)}
                  />
                </Form.Group>
              </Col>
              <Col>
                <Form.Group>
                  <Form.Label>Routebeschrijving</Form.Label>
                  <Form.Control
                    type={"email"}
                    placeholder={"Enter bedrijf email"}
                    value={Routebeschrijving}
                    onChange={(e) => setRoutebeschrijving(e.target.value)}
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
    </>
  );
}

export default CreateNewUitnodiging;
